using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGalaxy : MonoBehaviour
{
    public static DisplayGalaxy displayGalaxy;
    public GameObject nodePrefab;
    public Transform galaxyPlaceholder;
    public Galaxy galaxy;

    private void Awake()
    {
        displayGalaxy = this;
        galaxy = new Galaxy();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(galaxy.nodes.Count);
        foreach (Node node in galaxy.nodes)
        {
            GameObject newNode = Instantiate(nodePrefab,new Vector3(node.position.x, node.position.y),new Quaternion(), galaxyPlaceholder);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
