using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
public class XMLUtility : MonoBehaviour
{
    
    public static string userXMLPath = Path.Combine(StaticData.userPath, "XML");

    public static string userSettingsXMLPath = Path.Combine(userXMLPath, "userSettings.xml");

    public static string userGalaxyXMLPath = Path.Combine(userXMLPath, "Galaxy");
    public static string userEmpireXMLPath = Path.Combine(userXMLPath, "Empire");

    
    public static void SaveUserXML<objectType>(string path, objectType objectToSerialize)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(objectType));
        Stream stream = new FileStream(Path.Combine(StaticData.userPath, path), FileMode.Create, FileAccess.Write);
        serializer.Serialize(stream, objectToSerialize);
        stream.Close();
    }
    public static objectType LoadUserXML<objectType>(string path) where objectType : new()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(objectType));
        FileStream stream = null;
        try
        {
            stream=new FileStream(Path.Combine(StaticData.userPath, path), FileMode.Open, FileAccess.Read);
        }
        catch (FileNotFoundException)
        {
            SaveUserXML<objectType>(Path.Combine(StaticData.userPath, path), new objectType());
            stream = new FileStream(Path.Combine(StaticData.userPath, path), FileMode.Open, FileAccess.Read);
        }
        objectType deserializedObject = (objectType)serializer.Deserialize(stream);
        stream.Close();
        return deserializedObject;
    }
    public static objectType LoadInternalXML<objectType>(string path)
    {
        TextAsset xmlFile = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(objectType));
        StringReader reader = new StringReader(xmlFile.ToString());
        objectType deserializedObject = (objectType) serializer.Deserialize(reader);
        reader.Close();
        return deserializedObject;
    }
}
