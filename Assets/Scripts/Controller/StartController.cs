using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class StartController : MonoBehaviour
{
    public static StartController startController;
    public static UserSettings userSettings;
    public List<Empire> avalableEmpires;
    public List<Galaxy> avalableGalaxies;
    private void Awake()
    {
        startController = this;

        userSettings = UserSettings.LoadUserSettings();
        //LoadEmpires();
    }
    private void LoadUserSettings()
    {
            
    }
    private void LoadEmpires()
    {
        foreach(string empirePaths in Directory.GetFiles(XMLUtility.userEmpireXMLPath))
            avalableEmpires.Add(XMLUtility.LoadUserXML<Empire>(empirePaths));
    }
}
