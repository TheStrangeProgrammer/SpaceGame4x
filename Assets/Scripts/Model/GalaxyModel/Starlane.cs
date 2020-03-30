using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuikGraph;
using System;

public class Starlane : IUndirectedEdge<Node>
{
    public int id;
    public CartezianLine line;
    public StarlaneType starlaneType;
    private readonly Node source;
    private readonly Node target;
    public Starlane(Node source, Node target) {
        this.source = source;
        this.target = target;
    }
    public void SetupStarlane(int id, StarlaneType starlaneType)
    {
        this.id = id;
        this.starlaneType = starlaneType;
    }
    public Node Source { get { return source; } }

    public Node Target { get { return target; } }
}
