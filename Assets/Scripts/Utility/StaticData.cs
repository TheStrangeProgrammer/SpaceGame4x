using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public static string userPath = Path.Combine(Application.persistentDataPath, "SpaceGame4x/");
    public static UnityEngine.Object LoadUnityResource(string path)
    {
        return Resources.Load(path);
    }
}
