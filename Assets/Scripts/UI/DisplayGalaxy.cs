using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGalaxy : MonoBehaviour
{
    public static DisplayGalaxy displayGalaxy;
    public GameObject nodePrefab;
    public GameObject starlanePrefab;
    public Transform galaxyPlaceholder;
    public Galaxy galaxy;
    public Dictionary<GameObject, Node> displayedNodes;
    public Dictionary<GameObject, Starlane> displayedStarlanes;
    private void Awake()
    {
        displayedNodes = new Dictionary<GameObject, Node>();
        displayedStarlanes=new Dictionary<GameObject, Starlane>();
    displayGalaxy = this;
        galaxy = new Galaxy();
    }
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
        Debug.Log(galaxy.nodes.Count);
        foreach (Node node in galaxy.nodes)
        {
            GameObject newDisplayedNode = Instantiate(nodePrefab,new Vector3(node.position.x, node.position.y),new Quaternion(), galaxyPlaceholder);
            displayedNodes.Add(newDisplayedNode, node);
            visited.Add(node, false);
        }

        foreach(Starlane starlane in galaxy.starlanes)
        {
            GameObject newDisplayedStarlane = Instantiate(starlanePrefab, galaxyPlaceholder);
            Vector3 endPosition = new Vector3(starlane.end.position.x, starlane.end.position.y);
            Vector3 startPosition = new Vector3(starlane.start.position.x, starlane.start.position.y);
            newDisplayedStarlane.transform.position = (endPosition - startPosition) / 2.0f + startPosition;

            Vector3 v3T = transform.localScale;      // Scale it
            v3T.x = 0.1f;
            v3T.z = 0.1f;
            v3T.y = (endPosition - startPosition).magnitude/2;
            newDisplayedStarlane.transform.localScale = v3T;

            // Rotate it
            newDisplayedStarlane.transform.rotation = Quaternion.FromToRotation(Vector3.up, endPosition - startPosition);
            displayedStarlanes.Add(newDisplayedStarlane, starlane);
        }
        /*Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(galaxy.nodes[0]);
        visited[galaxy.nodes[0]] = true;
        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();
            foreach (Starlane starlane in node.starlanes)
            {
                GameObject newDisplayedStarlane = Instantiate(starlanePrefab, galaxyPlaceholder);
                Vector3 endPosition = new Vector3(starlane.end.position.x, starlane.end.position.y);
                Vector3 startPosition = new Vector3(starlane.start.position.x, starlane.start.position.y);
                newDisplayedStarlane.transform.localPosition = (endPosition - startPosition) / 2.0f + startPosition;

                Vector3 v3T = transform.localScale;      // Scale it
                v3T.x = 0.1f;
                v3T.z = 0.1f;
                v3T.y = (endPosition - startPosition).magnitude;
                newDisplayedStarlane.transform.localScale = v3T;

                // Rotate it
                newDisplayedStarlane.transform.rotation = Quaternion.FromToRotation(Vector3.up, endPosition - startPosition);
                displayedStarlanes.Add(newDisplayedStarlane, starlane);
                if (!visited[starlane.end])
                {
                    visited[starlane.end] = true;
                    queue.Enqueue(starlane.end);
                }
            }
           

        }
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
