using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starlane
{
    public CartezianLine line;
    public string texturePath = "";
    public Node start;
    public Node end;
    public Starlane(CartezianLine line,Node start, Node end)
    {
        this.line = line;
        this.start = start;
        this.end = end;
    }
}
