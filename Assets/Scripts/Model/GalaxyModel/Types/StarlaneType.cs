using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
[XmlRoot("StarlaneType")]
public class StarlaneType {
    [XmlElement]
    int id;

    [XmlElement]
    public string texturePath = "starlane.png";
    public StarlaneType()
    {
        id = -1;
    }
}
