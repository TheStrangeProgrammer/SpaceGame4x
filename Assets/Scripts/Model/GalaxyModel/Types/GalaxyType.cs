using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("GalaxyType")]
public class GalaxyType
{
    [XmlElement]
    public string typeName;
    [XmlElement]
    public string texturePath;
    
    [XmlElement]
    public int numberOfNodes;

    [XmlElement]
    public int minimumRadius;
    [XmlElement]
    public int maximumRadius;
    [XmlElement]
    public int minDistanceBetweenNodes;


    [XmlElement]
    public bool hasArms;
    [XmlElement]
    public int numberOfArms;

    [XmlElement]
    public bool hasCenter;
    [XmlElement]
    public int percentageStarsCentre;

    
    [XmlElement]
    public float minAngleBetweenConnections;
    [XmlElement]
    public int maxDistanceBetweenNodesToConnect;
    [XmlElement]
    public int maxConnectionsPerNode;

    [XmlArray("nodeTypePercentages")]
    [XmlArrayItem("nodeTypePercentage")]
    public List<Pair<string, int>> nodeTypePercentages;

    [XmlArray("possibleNames")]
    [XmlArrayItem("possibleName")]
    public List<string> possibleNames;
}
