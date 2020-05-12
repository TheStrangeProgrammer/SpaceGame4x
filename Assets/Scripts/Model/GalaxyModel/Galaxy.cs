using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[XmlRoot("Galaxy")]
public class Galaxy
{
    [XmlElement]
    public int id;
    [XmlElement]
    public string galaxyName;
    [XmlElement]
    public string galaxyTypeName;
    [XmlElement]
    public int seed;
    [XmlIgnore]
    public GalaxyType galaxyType;
    public Galaxy()
    {

    }
    public Galaxy(int id, GalaxyType galaxyType)
    {
        
        this.id = id;
        this.galaxyType = galaxyType;
        new RandomUtility(seed);
        galaxyName = galaxyType.possibleNames[RandomUtility.random.Next(0, galaxyType.possibleNames.Count)];
    }
}
