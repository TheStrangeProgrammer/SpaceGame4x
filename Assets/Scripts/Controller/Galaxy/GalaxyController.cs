using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using QuikGraph;
using QuikGraph.Algorithms;
using System.IO;
using System.Linq;
using QuikGraph.Collections;
using System;

public class GalaxyController
{
    public static GalaxyController galaxyController;
    public Galaxy galaxy;
    
    private Dictionary<int,GalaxyType> galaxyTypes;
    [XmlIgnore]
    private Dictionary<Starlane, int> edgeCosts = new Dictionary<Starlane, int>();
    [XmlIgnore]
    public UndirectedGraph<Node, Starlane> graph;
    public GalaxyController()
    {

        galaxyController = this;
        galaxyTypes = new Dictionary<int, GalaxyType>();
        LoadXML();
        galaxy=new Galaxy(galaxyTypes[0]);
        Generate();
        new NodeController();
        //graph = new UndirectedGraph<Node, Starlane>(false, (edge, source, target) => { return edge.Source == target && edge.Target == source; });

        //galaxyController = this;
        //galaxy = new Galaxy();
        //galaxy.galaxyType.nodeTypes = new List<int>();
        //Galaxy.SaveXML(galaxy);
        //galaxy.nodeTypes = new List<Node>();
    }
    public void LoadXML()
    {
        foreach (GalaxyType galaxyType in XMLUtility.LoadAllInternalXMLInFolder<GalaxyType>("XML/Types/GalaxyTypes"))
        {
            galaxyTypes.Add(galaxyType.id, galaxyType);
        }
    }

    public void Generate()
    {
        graph = new UndirectedGraph<Node, Starlane>(false, (edge, source, target) => { return edge.Source == target && edge.Target == source; });
        if (!galaxy.galaxyType.hasCenter)
        {
            galaxy.galaxyType.hasArms = false;
        }
        if (galaxy.galaxyType.hasCenter)
        {
            galaxy.galaxyType.minimumRadius = 0;
        }
        RandomUtility.random = new Random();
        
        GenerateNodes();
        GenerateLanes();
        printpath();
    }
    int RandomNumber(int min, int max)
    {

        return RandomUtility.random.Next(min, max);
    }
    double RandomDouble()
    {

        return RandomUtility.random.NextDouble();
    }
    void printpath()
    {
        //Debug.Log(galaxy.);
    }
    CartezianPosition GenerateRandomPosition()
    {
        CartezianPosition positionToReturn = null;

        double angle = RandomUtility.random.NextDouble() * 2 * Math.PI;
        double randomTheta = Math.Sqrt(RandomUtility.random.NextDouble());
        double radiusMax = (galaxy.galaxyType.maximumRadius - galaxy.galaxyType.minimumRadius) * randomTheta;
        double radiusMin = galaxy.galaxyType.minimumRadius;
        double x = radiusMax * Math.Cos(angle) + radiusMin * Math.Cos(angle);
        double y = radiusMax * Math.Sin(angle) + radiusMin * Math.Sin(angle);
        positionToReturn = new CartezianPosition(Convert.ToInt32(x), Convert.ToInt32(y));
        /*
        else {
            int positiveRandomX = RandomNumber(minimumRadius, maximumRadius);
            int negativeRandomX = RandomNumber(-maximumRadius, -minimumRadius);

            int positiveRandomY = RandomNumber(minimumRadius, maximumRadius);
            int negativeRandomY = RandomNumber(-maximumRadius, -minimumRadius);

            bool choosePositionX = RandomNumber(0,100) <= 50 ? true : false;
            bool choosePositionY = RandomNumber(0, 100) <= 50 ? true : false;

            positionToReturn = new CartezianPosition(choosePositionX ? positiveRandomX : negativeRandomX, choosePositionY ? positiveRandomY : negativeRandomY);
        }*/

        if (positionToReturn != null)
        {
            return positionToReturn;
        }
        else
        {
            return new CartezianPosition(RandomNumber(-galaxy.galaxyType.maximumRadius, galaxy.galaxyType.maximumRadius), RandomNumber(-galaxy.galaxyType.maximumRadius, galaxy.galaxyType.maximumRadius));
        }
    }
    void GenerateNodes()
    {
        int impossibleProbability = 0;
        bool impossible = false;
        if (graph.VertexCount == 0)
        {
            CartezianPosition nodePosition = GenerateRandomPosition();
            graph.AddVertex(new Node(nodePosition));

        }
        if (galaxy.galaxyType.numberOfArms == 0)
        {
            for (int i = 1; i < galaxy.galaxyType.numberOfNodes && !impossible; i++)
            {

                CartezianPosition nodePosition = GenerateRandomPosition();
                bool canBeAdded = true;
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    if (CartezianPosition.IsDistanceLessThan(graph.Vertices.ElementAt(j).position, nodePosition, galaxy.galaxyType.minDistanceBetweenNodes))
                    {
                        i--;
                        impossibleProbability++;
                        canBeAdded = false;
                        break;
                    }
                }
                if (canBeAdded)
                    graph.AddVertex(new Node(nodePosition));
                if (impossibleProbability == galaxy.galaxyType.numberOfNodes * 2)
                {
                    impossible = true;
                }
            }

        }
    }

    void GenerateLanes()
    {

        foreach (Node node in graph.Vertices)
        {
            IOrderedEnumerable<Node> orderedNodes = graph.Vertices.OrderBy(nodeToOrder => CartezianPosition.CalculateDistance(node.position, nodeToOrder.position));
            IEnumerator<Node> enumeratorNodes = orderedNodes.GetEnumerator();
            enumeratorNodes.MoveNext();
            enumeratorNodes.MoveNext();
            if (CartezianPosition.CalculateDistance(enumeratorNodes.Current.position, node.position) > galaxy.galaxyType.maxDistanceBetweenNodesToConnect)
            {
                Node reference = enumeratorNodes.Current;
                Starlane newEdge = new Starlane(node, reference);
                graph.AddEdge(newEdge);
                edgeCosts.Add(newEdge, CartezianPosition.CalculateDistance(enumeratorNodes.Current.position, node.position));
                //node.starlanes.Add(new Starlane(new CartezianLine(node.position,orderedNodes.ElementAt(1).position),node, orderedNodes.ElementAt(1)));
                //orderedNodes.ElementAt(1).starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), orderedNodes.ElementAt(1), node));
                //graph.AddEdge(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), node, orderedNodes.ElementAt(1)));
                //graph.AddEdge(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), orderedNodes.ElementAt(1), node));
            }
            else
            {
                for (int j = 1; j < 6; j++)
                {
                    if (graph.AdjacentEdges(node).Count() < galaxy.galaxyType.maxConnectionsPerNode && graph.AdjacentEdges(enumeratorNodes.Current).Count() < galaxy.galaxyType.maxConnectionsPerNode)
                    {
                        bool foundIntersection = false;

                        foreach (Node linkNode in graph.AdjacentVertices(enumeratorNodes.Current))
                        {
                            foreach (Node linkOfLinkNode in graph.AdjacentVertices(linkNode))
                            {
                                if (CartezianLine.LineSegmentsIntersect(new CartezianLine(node.position, enumeratorNodes.Current.position), new CartezianLine(linkNode.position, linkOfLinkNode.position)))
                                {
                                    foundIntersection = true;
                                }

                            }
                        }
                        foreach (Node linkNode in graph.AdjacentVertices(node))
                        {
                            foreach (Node linkOfLinkNode in graph.AdjacentVertices(linkNode))
                            {
                                if (CartezianLine.LineSegmentsIntersect(new CartezianLine(node.position, enumeratorNodes.Current.position), new CartezianLine(linkNode.position, linkOfLinkNode.position)))
                                {
                                    foundIntersection = true;
                                }

                            }
                        }

                        if (foundIntersection == false)
                        {
                            Node reference = enumeratorNodes.Current;
                            Starlane newEdge = new Starlane(node, reference);
                            graph.AddEdge(newEdge);
                            edgeCosts.Add(newEdge, CartezianPosition.CalculateDistance(enumeratorNodes.Current.position, node.position));
                            //node.starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), node, orderedNodes.ElementAt(j)));
                            //orderedNodes.ElementAt(j).starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), orderedNodes.ElementAt(j), node));
                            //graph.AddEdge(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), node, orderedNodes.ElementAt(j)));
                            //graph.AddEdge(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), orderedNodes.ElementAt(j), node));
                        }
                    }
                    enumeratorNodes.MoveNext();
                }
            }
        }
    }
}
