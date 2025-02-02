﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuikGraph;
using System.IO;
using System;


public class GalaxyView : MonoBehaviour
{
    public static GalaxyView displayGalaxy;
    public GameObject nodePrefab;
    public GameObject starlanePrefab;
    private Transform galaxyPlaceholder;
    public GalaxyController galaxy;
    public Dictionary<GameObject, Node> displayedNodes;
    public Dictionary<GameObject, Starlane> displayedStarlanes;
    public List<TextMesh> namePlates;
    private void Awake()
    {
        galaxyPlaceholder = this.transform;
        displayedNodes = new Dictionary<GameObject, Node>();
        displayedStarlanes = new Dictionary<GameObject, Starlane>();
        galaxy = new GalaxyController();
        galaxy.LoadXML();
        galaxy.Generate();
        displayGalaxy = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(galaxy.graph.VertexCount);
        Debug.Log(galaxy.graph.EdgeCount);
        foreach (Node node in galaxy.graph.Vertices)
        {
            GameObject newDisplayedNode = Instantiate(nodePrefab, new Vector3(node.position.x, node.position.y), new Quaternion(), galaxyPlaceholder);
            TextMesh nameText = new GameObject(node.nodeName + " Name Plate").AddComponent<TextMesh>();
            nameText.transform.SetParent(newDisplayedNode.transform);
            nameText.text = node.nodeName;
            nameText.transform.localPosition = new Vector3(0, -1.2f, 0);
            nameText.anchor = TextAnchor.MiddleCenter;
            nameText.alignment = TextAlignment.Center;
            nameText.color = Color.white;
            nameText.fontSize = 10;
            nameText.gameObject.isStatic = true;
            nameText.transform.Rotate(new Vector3(0, 0, 1f), CameraController.currentAngle.z);
            namePlates.Add(nameText);
            newDisplayedNode.GetComponent<Renderer>().material.mainTexture = TextureUtility.LoadUserPNG(Path.Combine(TextureUtility.userNodesTexturePath,node.texturePath));
            displayedNodes.Add(newDisplayedNode, node);
        }

        foreach (Starlane starlane in galaxy.graph.Edges)
        {
            GameObject newDisplayedStarlane = Instantiate(starlanePrefab, galaxyPlaceholder);
            Vector3 endPosition = new Vector3(starlane.Target.position.x, starlane.Target.position.y);
            Vector3 startPosition = new Vector3(starlane.Source.position.x, starlane.Source.position.y);
            newDisplayedStarlane.transform.position = (endPosition - startPosition) / 2.0f + startPosition;
            newDisplayedStarlane.GetComponent<Renderer>().material.mainTexture = TextureUtility.LoadUserPNG(Path.Combine(TextureUtility.userStarlanesTexturePath, starlane.texturePath));
            Vector3 v3T = transform.localScale;      // Scale it
            v3T.x = 0.1f;
            v3T.z = 0.1f;
            v3T.y = (endPosition - startPosition).magnitude / 2;
            newDisplayedStarlane.transform.localScale = v3T;

            // Rotate it
            newDisplayedStarlane.transform.rotation = Quaternion.FromToRotation(Vector3.up, endPosition - startPosition);
            displayedStarlanes.Add(newDisplayedStarlane, starlane);
        }
    }

    void Update()
    {
        if (namePlates.Count > 0)
        {
            if (CameraController.cameraController.zoomLevel < 0.4)
            {
                for (int i = 0; i < namePlates.Count; i++)
                {
                    namePlates[i].transform.LookAt(Camera.main.transform);
                    float rotY = namePlates[i].transform.localEulerAngles.y + 180f;
                    namePlates[i].transform.localEulerAngles = new Vector3(
                        -namePlates[i].transform.localEulerAngles.x,
                            rotY,
                        -namePlates[i].transform.localEulerAngles.z);
                }
            }
        }
    }
}
