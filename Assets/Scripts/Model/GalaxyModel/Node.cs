using System.Collections;
using System.Collections.Generic;
using QuikGraph;
using QuikGraph.Algorithms;
using System;
public class Node
{
    public int id;
    public CartezianPosition position;
    public string nodeName;
    public NodeType nodeType;
    public int planetAmount;
    public Node()
    {
        id = -1;
    }
    public Node(CartezianPosition position)
    {
         this.position = position;
    }
    public void SetupNode(int id, NodeType nodeType)
    {
        this.id = id;
        this.nodeType = nodeType;
        nodeName = nodeType.possibleNames[RandomUtility.random.Next(0, nodeType.possibleNames.Count)];
        planetAmount = RandomUtility.random.Next(nodeType.minPlanetAmount, nodeType.maxPlanetAmount);
    }
}
