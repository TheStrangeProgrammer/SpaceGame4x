﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("NodeType")]
public class NodeType
{
    [XmlElement]
    public int id;
    [XmlElement]
    public string typeName;
    [XmlElement]
    public string typeDescription;
    [XmlElement]
    public string texturePath = "node.png";

    [XmlElement]
    public int minPlanetAmount;
    [XmlElement]
    public int maxPlanetAmount;

    [XmlArray("possibleNames")]
    [XmlArrayItem("possibleName")]
    public List<string> possibleNames;

    [XmlArray("possibleNamingConventions")]
    [XmlArrayItem("possibleNamingConvention")]
    public List<string> possibleNamingConventions;

    [XmlArray("planetTypePercentages")]
    [XmlArrayItem("planetTypePercentage")]
    public List<Pair<int, int>> planetTypePercentages;

    [XmlArray("specialResourceTypePercentages")]
    [XmlArrayItem("specialResourceTypePercentage")]
    public List<Pair<int, int>> specialResourceTypePercentages;
    public NodeType()
    {
        id = -1;
        texturePath = "node.png";
        minPlanetAmount=1;
        maxPlanetAmount = 10;
        possibleNames = new List<string>() { "nodeName1", "nodeName2", "nodeName3" };
    }
}