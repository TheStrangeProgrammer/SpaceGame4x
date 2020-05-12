using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarlaneController
{
    public static StarlaneController starlaneController;
    private Dictionary<int, StarlaneType> starlaneTypes;
    Dictionary<Starlane, int> starlaneTravelCost;
    public StarlaneController()
    {
        starlaneController = this;
        starlaneTypes = new Dictionary<int, StarlaneType>();
        LoadInternalXML();
        SetupStarlanes();
    }
    public void LoadInternalXML()
    {
        foreach (StarlaneType starlaneType in XMLUtility.LoadAllInternalXMLInFolder<StarlaneType>("XML/Types/StarlaneTypes"))
        {
            starlaneTypes.Add(starlaneType.id, starlaneType);
        }
    }
    void SetupStarlanes()
    {
        int i = 0;
        foreach (Starlane starlane in GalaxyController.galaxyController.graph.Edges)
        {
            starlane.SetupStarlane(i, starlaneTypes[0]);
            i++;
        }
    }
}
