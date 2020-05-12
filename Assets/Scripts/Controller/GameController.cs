using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    //galaxyControllers
    private GalaxyController galaxyController;
    private NodeController nodeController;
    private StarlaneController starlaneController;
    private PlanetController planetController;
    //empireControllers
    private EmpireController empireController;
    private PopulationController populationController;
    private GovernmentController governmentController;
    private EthicsController ethicsController;
    private void Awake()
    {
        //galaxyControllers
        //galaxyController = new GalaxyController();
        // nodeController = new NodeController();
        // starlaneController = new StarlaneController();
        // planetController = new PlanetController();
        //empireControllers

    }

    void StartGame()
    {
       // galaxyController.Generate();
    }

    void LoadGame()
    {
        //galaxyController.LoadGame();
    }
    void LoadEmpiresFromExternalXML()
    {

    }
}
