using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node
{
    public int id;
    public CartezianPosition position = new CartezianPosition(0,0);
    public string name;
    public string texturePath = "";
    public List<Node> links = new List<Node>();

    public Node(int id,string name, CartezianPosition position)
    {
        this.id = id;
        this.name = name;
        this.position = position;
    }
}
