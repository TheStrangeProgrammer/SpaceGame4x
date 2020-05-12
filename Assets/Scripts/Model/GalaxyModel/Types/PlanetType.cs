using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("PlanetType")]
public class PlanetType
{
    [XmlElement]
    public int id;
    [XmlElement]
    public string description;
    [XmlElement]
    public string texturePath = "planet.png";


    [XmlElement]
    public int minFood;
    [XmlElement]
    public int maxFood;
    [XmlElement]
    public int minResearch;
    [XmlElement]
    public int maxResearch;
    [XmlElement]
    public int minIndustry;
    [XmlElement]
    public int maxIndustry;
    [XmlElement]
    public int minMoney;
    [XmlElement]
    public int maxMoney;
    [XmlElement]
    public int fertilityType;
    [XmlElement]
    public int atmosphereType;
    [XmlElement]
    public int climateType;


    //[XmlArray("orbitPositionsPercentages")]
    //[XmlArrayItem("orbitPositionsPercentage")]
    //public Dictionary<int, int> orbitPositionsPercentages;

    //[XmlArray("specialResourceTypePercentages")]
   // [XmlArrayItem("specialResourceTypePercentage")]
    //public Dictionary<int, int> specialResourceTypePercentages;
    public PlanetType()
    {
        id = -1;
    }
}
