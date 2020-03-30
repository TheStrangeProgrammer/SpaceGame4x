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
    private Galaxy galaxy;
    [XmlIgnore]
    private Dictionary<Starlane, int> edgeCosts = new Dictionary<Starlane, int>();
    [XmlIgnore]
    public UndirectedGraph<Node, Starlane> graph;
    Random random;
    public GalaxyController()
    {

        graph = new UndirectedGraph<Node, Starlane>(false, (edge, source, target) => { return edge.Source == target && edge.Target == source; });
        
        galaxyController = this;
        galaxy = new Galaxy();
        galaxy.nodeTypes = new List<Node>();
        //Galaxy.SaveXML(galaxy);
        //galaxy.nodeTypes = new List<Node>();
    }
    public void LoadXML()
    {
        galaxy = Galaxy.LoadXML("galaxy.xml");
    }
    public string getnodenr()
    {
        return galaxy.numberOfNodes.ToString();
    }
    public void Generate()
    {
        if (!galaxy.hasCenter)
        {
            galaxy.hasArms = false;
        }
        if (galaxy.hasCenter)
        {
            galaxy.minimumRadius = 0;
        }
        random = new Random();
        
        GenerateNodes();
        GenerateLanes();
        printpath();
    }
    int RandomNumber(int min, int max)
    {

        return random.Next(min, max);
    }
    double RandomDouble()
    {

        return random.NextDouble();
    }
    void printpath()
    {
        //Debug.Log(galaxy.);
    }
    CartezianPosition GenerateRandomPosition()
    {
        CartezianPosition positionToReturn = null;

        double angle = random.NextDouble() * 2 * Math.PI;
        double randomTheta = Math.Sqrt(random.NextDouble());
        double radiusMax = (galaxy.maximumRadius - galaxy.minimumRadius) * randomTheta;
        double radiusMin = galaxy.minimumRadius;
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
            return new CartezianPosition(RandomNumber(-galaxy.maximumRadius, galaxy.maximumRadius), RandomNumber(-galaxy.maximumRadius, galaxy.maximumRadius));
        }
    }
    void GenerateNodes()
    {
        int impossibleProbability = 0;
        bool impossible = false;
        if (graph.VertexCount == 0)
        {
            CartezianPosition nodePosition = GenerateRandomPosition();
            graph.AddVertex(CreateNode(0, "Star0", nodePosition));

        }
        if (galaxy.numberOfArms == 0)
        {
            for (int i = 1; i < galaxy.numberOfNodes && !impossible; i++)
            {

                CartezianPosition nodePosition = GenerateRandomPosition();
                bool canBeAdded = true;
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    if (CartezianPosition.IsDistanceLessThan(graph.Vertices.ElementAt(j).position, nodePosition, galaxy.minDistanceBetweenNodes))
                    {
                        i--;
                        impossibleProbability++;
                        canBeAdded = false;
                        break;
                    }
                }
                if (canBeAdded)
                    graph.AddVertex(CreateNode(i,"Star"+i,nodePosition));
                if (impossibleProbability == galaxy.numberOfNodes * 2)
                {
                    impossible = true;
                }
            }

        }
    }
    Node CreateNode(int id,string nodeName, CartezianPosition nodePosition)
    {
        Node newNode = new Node(id, nodeName, nodePosition);
        newNode.GeneratePlanets();
        return newNode;
    }
    void GenerateLanes()
    {

        foreach (Node node in graph.Vertices)
        {
            IOrderedEnumerable<Node> orderedNodes = graph.Vertices.OrderBy(nodeToOrder => CartezianPosition.CalculateDistance(node.position, nodeToOrder.position));
            IEnumerator<Node> enumeratorNodes = orderedNodes.GetEnumerator();
            enumeratorNodes.MoveNext();
            enumeratorNodes.MoveNext();
            if (CartezianPosition.CalculateDistance(enumeratorNodes.Current.position, node.position) > galaxy.maxDistanceBetweenNodesToConnect)
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
                    if (graph.AdjacentEdges(node).Count() < galaxy.maxConnectionsPerNode && graph.AdjacentEdges(enumeratorNodes.Current).Count() < galaxy.maxConnectionsPerNode)
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
