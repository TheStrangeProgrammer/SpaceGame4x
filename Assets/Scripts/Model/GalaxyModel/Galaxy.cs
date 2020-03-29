using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Collections;
[XmlRoot("Galaxy")]
public class Galaxy
{

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

    [XmlArray("nodeTypes")]
    [XmlArrayItem("nodeType")]
    public List<Node> nodeTypes;
    [XmlElement("minAngleBetweenConnections")]
    public float minAngleBetweenConnections = 25f;
    [XmlElement("maxDistanceBetweenNodesToConnect")]
    public int maxDistanceBetweenNodesToConnect = 40;
    [XmlElement("maxConnectionsPerNode")]
    public int maxConnectionsPerNode = 5;

    public Galaxy()
    {
        
    }
    public static void SaveXML(Galaxy galaxy, string galaxySettingsName)
    {
        XMLUtility.SaveUserXML<Galaxy>(Path.Combine(XMLUtility.userGalaxyXMLPath,galaxySettingsName),galaxy);
    }
    public static Galaxy LoadXML(string galaxySettingsName)
    {
        
        return XMLUtility.LoadUserXML<Galaxy>(Path.Combine(XMLUtility.userGalaxyXMLPath, galaxySettingsName));
    }
}
