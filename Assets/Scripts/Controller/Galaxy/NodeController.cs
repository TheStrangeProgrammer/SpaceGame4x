using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController
{/*
    public static NodeController nodeController;
    private Dictionary<int, NodeType> nodeTypes;
    Dictionary<Node,List<Planet>> planets;
    public NodeController()
    {
        nodeController = this;
        
        nodeTypes = new Dictionary<int, NodeType>();
        LoadXML();
        SetupNodes();
    }
    public void LoadXML()
    {
        foreach (NodeType nodeType in XMLUtility.LoadAllInternalXMLInFolder<NodeType>("XML/Types/NodeTypes"))
        {
            nodeTypes.Add(nodeType.id, nodeType);
        }
    }
    void SetupNodes()
    {
        List<Pair<int, int>> typePercentages = GalaxyController.galaxyController.galaxy.galaxyType.nodeTypePercentages;
        int percentageSum = 0;
        foreach (Pair<int, int> typePercentagePair in typePercentages)
            percentageSum += typePercentagePair.value;

        int i = 0;
        foreach (Node node in GalaxyController.galaxyController.graph.Vertices)
        {
            int pickedNumber = RandomUtility.random.Next(0, percentageSum);
        int pickedType = -1;
        foreach (Pair<int, int> typePercentagePair in typePercentages)
        {
            if(typePercentagePair.value>= pickedNumber)
            {
                pickedType = typePercentagePair.key;
                break;
            }
        }

        
            node.SetupNode(i, nodeTypes[pickedType]);
            i++;
        }
    }
    public void GeneratePlanets()
    {
        
    }*/
}
