using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("GalaxyType")]
public class GalaxyType
{
    [XmlElement]
    public int id;
    [XmlElement]
    public string typeName;
    [XmlElement]
    public string texturePath = "galaxy.png";
    [XmlElement]
    public int seed;
    [XmlElement("numberOfNodes")]
    public int numberOfNodes = 400;

    [XmlElement("minimumRadius")]
    public int minimumRadius = 0;
    [XmlElement("maximumRadius")]
    public int maximumRadius = 100;
    [XmlElement("minDistanceBetweenNodes")]
    public int minDistanceBetweenNodes = 5;


    [XmlElement("hasArms")]
    public bool hasArms = false;
    [XmlElement("numberOfArms")]
    public int numberOfArms = 0;

    [XmlElement("hasCenter")]
    public bool hasCenter = false;
    [XmlElement("percentageStarsCentre")]
    public int percentageStarsCentre = 25;

    
    [XmlElement("minAngleBetweenConnections")]
    public float minAngleBetweenConnections = 25f;
    [XmlElement("maxDistanceBetweenNodesToConnect")]
    public int maxDistanceBetweenNodesToConnect = 40;
    [XmlElement("maxConnectionsPerNode")]
    public int maxConnectionsPerNode = 5;

    [XmlArray("nodeTypePercentages")]
    [XmlArrayItem("nodeTypePercentage")]
    public List<Pair<int, int>> nodeTypePercentages;

    [XmlArray("possibleNames")]
    [XmlArrayItem("possibleName")]
    public List<string> possibleNames;
}
