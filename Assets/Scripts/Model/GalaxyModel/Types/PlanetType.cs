using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[XmlRoot("PlanetType")]
public class PlanetType
{
    [XmlElement]
    int id;

    [XmlElement]
    public string texturePath = "planet.png";

    [XmlArray("possibleNames")]
    [XmlArrayItem("possibleName")]
    public List<string> possibleNames;
    public PlanetType()
    {
        id = -1;
    }
}
