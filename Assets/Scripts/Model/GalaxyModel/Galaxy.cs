using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Galaxy
{
    public int id;
    public string galaxyName;
    public GalaxyType galaxyType;
    public Galaxy(GalaxyType galaxyType)
    {
        this.galaxyType = galaxyType;
        id = 0;
        new RandomUtility(galaxyType.seed);
        galaxyName = galaxyType.possibleNames[RandomUtility.random.Next(0, galaxyType.possibleNames.Count)];
    }
}
