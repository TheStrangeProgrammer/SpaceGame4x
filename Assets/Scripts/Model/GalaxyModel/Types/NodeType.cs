using System.Collections;
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
    public string texturePath = "node.png";

    [XmlElement]
    public int minPlanetAmount;
    [XmlElement]
    public int maxPlanetAmount;

    [XmlArray("possibleNames")]
    [XmlArrayItem("possibleName")]
    public List<string> possibleNames;

    [XmlArray("planetTypePercentages")]
    [XmlArrayItem("planetTypePercentage")]
    public List<Pair<int, int>> planetTypePercentages;
    public NodeType()
    {
        id = -1;
        texturePath = "node.png";
        minPlanetAmount=1;
        maxPlanetAmount = 10;
        possibleNames = new List<string>() { "nodeName1", "nodeName2", "nodeName3" };
    }
}
