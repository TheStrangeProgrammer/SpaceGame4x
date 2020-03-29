using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuikGraph;
using System;

public class Starlane : IUndirectedEdge<Node>
{
    public CartezianLine line;
    public string texturePath = "starlane.png";
    private readonly Node source;
    private readonly Node target;
    public Starlane(Node source, Node target) {
        this.source = source;
        this.target = target;
    }

    public Node Source { get { return source; } }

    public Node Target { get { return target; } }
}
