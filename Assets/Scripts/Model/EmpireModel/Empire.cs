using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System;
[XmlRoot("Empire")]
public class Empire
{
    [XmlElement]
    public int id;
    [XmlElement]
    public string name;
    [XmlElement]
    public string description;
    [XmlArray("populationTypes")]
    [XmlArrayItem("populationType")]
    public List<int> populationTypes;
    [XmlElement]
    public int government;
    public Empire()
    {
        id = 0;
        name = "none";
    }
    public static void SaveXML(Empire empire,string empireName)
    {
        XMLUtility.SaveUserXML<Empire>(Path.Combine(XMLUtility.userGalaxyXMLPath, empireName), empire);
    }
    public static Empire LoadXML(string empireName)
    {
        return XMLUtility.LoadUserXML<Empire>(Path.Combine(XMLUtility.userGalaxyXMLPath, empireName));
    }
}
