using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node
{
    public int id;
    public CartezianPosition position;
    public string name;
    public string texturePath = "";
    public List<Starlane> starlanes = new List<Starlane>();

    public Node(int id,string name, CartezianPosition position)
    {
        this.id = id;
        this.name = name;
        this.position = position;
    }
}
