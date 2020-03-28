using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Galaxy
{
    public static Galaxy galaxy;
    public int numberOfNodes = 100;
    public int numberOfArms = 0;

    public int maximumRadius = 100;
    public int minDistanceBetweenNodes = 5;

    public float minAngleBetweenConnections = 25f;
    public int maxDistanceBetweenConnections = 10;
    public int maxConnections = 5;
    Random random;
    public List<Node> nodes = new List<Node>();
    public List<Starlane> starlanes = new List<Starlane>();
    public Galaxy()
    {
        random = new Random();
        galaxy = this;
        
        GenerateNodes();
        GenerateLanes();
    }
    int RandomNumber(int min, int max)
    {
        
        return random.Next(min, max);
    }
    void GenerateNodes()
    {
        if (nodes.Count == 0)
        {
            CartezianPosition nodePosition = new CartezianPosition(RandomNumber(-maximumRadius, maximumRadius), RandomNumber(-maximumRadius, maximumRadius));
            nodes.Add(new Node(0, "Star" + 0, nodePosition));
            
        }
        if (numberOfArms == 0)
        {
            for (int i = 1; i < numberOfNodes; i++)
            {

                CartezianPosition nodePosition = new CartezianPosition( RandomNumber(-maximumRadius, maximumRadius), RandomNumber(-maximumRadius, maximumRadius) );
                bool canBeAdded = true;
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (CartezianPosition.IsDistanceLessThan(nodes[j].position, nodePosition, minDistanceBetweenNodes))
                        {
                            i--;
                        canBeAdded = false;
                            break;
                        }
                    }
                if(canBeAdded)
                nodes.Add(new Node(i, "Star" + i, nodePosition));

            }

        }
    }
    void GenerateLanes()
    {

        foreach (Node node in nodes)
        {
            IEnumerable<Node> orderedNodes = nodes.OrderBy(nodeToOrder => CartezianPosition.CalculateDistance(node.position, nodeToOrder.position));
            if (CartezianPosition.CalculateDistance(orderedNodes.ElementAt(1).position, node.position) > maxDistanceBetweenConnections)
            {
                node.starlanes.Add(new Starlane(new CartezianLine(node.position,orderedNodes.ElementAt(1).position),node, orderedNodes.ElementAt(1)));
                orderedNodes.ElementAt(1).starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), orderedNodes.ElementAt(1), node));
                starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), node, orderedNodes.ElementAt(1)));
                starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(1).position), orderedNodes.ElementAt(1), node));
            }
            else
            {
                for (int j = 1; j < 6; j++)
                {
                    if (node.starlanes.Count < 5 && orderedNodes.ElementAt(j).starlanes.Count < 5)
                    {
                        bool foundIntersection = false;
                        foreach (Starlane linkNode in orderedNodes.ElementAt(j).starlanes)
                        {
                            foreach (Starlane linkOfLinkNode in linkNode.end.starlanes)
                            {
                                if (CartezianLine.LineSegmentsIntersect(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), linkOfLinkNode.line))
                                {
                                    foundIntersection = true;
                                }
                            }
                        }

                        if (foundIntersection == false)
                        {
                            node.starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), node, orderedNodes.ElementAt(j)));
                            orderedNodes.ElementAt(j).starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), orderedNodes.ElementAt(j), node));
                            starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), node, orderedNodes.ElementAt(j)));
                            starlanes.Add(new Starlane(new CartezianLine(node.position, orderedNodes.ElementAt(j).position), orderedNodes.ElementAt(j), node));
                        }
                    }

                }
            }
        }
    }
}
