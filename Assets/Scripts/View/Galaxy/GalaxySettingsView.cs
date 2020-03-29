using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxySettingsView : MonoBehaviour
{
    public Transform canvas;

    public GameObject galaxyOptionsPlaceholder;
    public GameObject galaxyOptionPrefab;

    public GameObject galaxyFilePrefab;

    public GalaxySettingsFromFileView galaxyFileSettings;
    private void Start()
    {
        GameObject newSettingsFromFile = Instantiate(galaxyFilePrefab, canvas);
    }


    public void SaveConfigurationAsXML()
    {

    }
    public void SaveToUseNow()
    {

    }
    public void LoadConfigurationFromXML()
    {
        
    }
    public void Exit()
    {
        Destroy(gameObject);
    }
}
