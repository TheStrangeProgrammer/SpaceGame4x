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
        using (Stream stream = new FileStream(Path.Combine(StaticData.userPath, path), FileMode.Create, FileAccess.Write))
        {
            serializer.Serialize(stream, objectToSerialize);
        }
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
        objectType deserializedObject;
        TextAsset xmlFile = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(objectType));
        using (StringReader reader = new StringReader(xmlFile.ToString()))
        {
            deserializedObject = (objectType)serializer.Deserialize(reader);
        }
        return deserializedObject;
    }
    public static List<objectType> LoadAllInternalXMLInFolder<objectType>(string path)
    {
        Debug.Log(path);
        TextAsset[] xmlFiles = Resources.LoadAll<TextAsset>(path);
        Debug.Log(xmlFiles.Length);
       List <objectType> deserializedObjects = new List<objectType>();
        foreach (TextAsset xmlFile in xmlFiles)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(objectType));
            using (StringReader reader = new StringReader(xmlFile.ToString()))
            {
                deserializedObjects.Add((objectType)serializer.Deserialize(reader));
            }
        }
        
        return deserializedObjects;
    }
}
