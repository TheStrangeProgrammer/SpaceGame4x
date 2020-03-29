using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuikGraph;
using QuikGraph.Algorithms;
public class Node{
    public int id;
    public CartezianPosition position;
    public string nodeName;
    public string texturePath = "node.png";
    //public List<Starlane> starlanes = new List<Starlane>();
    public Node()
    {
        id = -1;
    }
    public Node(int id, CartezianPosition position)
    {
        this.id = id;
        this.position = position;
    }

    

    public void GeneratePlanets()
    {

    }
}
