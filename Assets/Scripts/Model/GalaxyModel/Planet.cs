using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    public int id;
    public string name;
    public int food;
    public int industry;
    public int research;
    public int money;
    public bool colonized;
    public int colonizedByEmpire;
    public string planetType;
    public int orbitPosition;
    public Dictionary<string,int> resources;
}
