using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController cameraController;

    public float panSpeed = 5;
    private float zoomedInAngle = 0;
    private float zoomedOutAngle = 0;
    private float minZoom = 0; 
    private float maxZoom = 0; 
    public bool inverseZoom = false;
    private Vector3 MouseStart, MouseMove;
    private Vector3 derp;
    public static Quaternion currentAngle;

    public float zoomLevel { get; set; }

    // Used before Start()
    void Awake()
    {
        zoomLevel = 0;
        cameraController = this;
        ResetCamera();
    }
    private void Start()
    {
        zoomedInAngle = -45;
        zoomedOutAngle = 0;
        minZoom = 20;
        maxZoom = 400;
    }
    // Update is called once per frame
    void Update()
    {

        ChangeZoom();
        ChangePosition();

    }

    // This method pans the camera view in the XZ plane
    void ChangePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetMouseButton(0))
        {
            MouseMove = new Vector3(Input.mousePosition.x - MouseStart.x, Input.mousePosition.y - MouseStart.y);
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObject.transform.position.z);
            transform.position = new Vector3(transform.position.x - MouseMove.x * Time.deltaTime*panSpeed, transform.position.y - MouseMove.y * Time.deltaTime * panSpeed, gameObject.transform.position.z);
        }
    }

    // This method changes the zoom of the camera
    void ChangeZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (inverseZoom == false)
            {
                zoomLevel = Mathf.Clamp01(zoomLevel - Input.GetAxis("Mouse ScrollWheel"));
                // Can only see planet text up until 0.4 zoom level.
            }
            else
            {
                zoomLevel = Mathf.Clamp01(zoomLevel + Input.GetAxis("Mouse ScrollWheel"));
            }

            float zoom = Mathf.Lerp(-minZoom, -maxZoom, zoomLevel);
            gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zoom);

            float zoomAngle = Mathf.Lerp(zoomedInAngle, zoomedOutAngle, zoomLevel);
            gameObject.transform.localRotation = Quaternion.Euler(zoomAngle, 0, 0);
            currentAngle = gameObject.transform.localRotation;

        }
    }


    // This method resets the camera to the centre of the scene
    public void ResetCamera()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        zoomLevel = 0;
        gameObject.transform.rotation = Quaternion.Euler(zoomedInAngle, 0, 0);
        currentAngle = gameObject.transform.rotation;
        gameObject.transform.localPosition = new Vector3(0, 0, -minZoom);
    }

    // This method stops the camera 
    void ClampCameraPan()
    {
        /*Vector3 position = this.transform.position;

        if (Galaxy.GalaxyInstance.galaxyView == true)
        {
            position.x = Mathf.Clamp(transform.position.x, -Galaxy.GalaxyInstance.maximumRadius, Galaxy.GalaxyInstance.maximumRadius);
            position.z = Mathf.Clamp(transform.position.z, -Galaxy.GalaxyInstance.maximumRadius, Galaxy.GalaxyInstance.maximumRadius);
        }
        else
        {
            position.x = Mathf.Clamp(transform.position.x, -50, 50);
            position.z = Mathf.Clamp(transform.position.z, -50, 50);
        }

        this.transform.position = position;
        */
    }

    public void MoveTo(Vector3 position)
    {
        this.transform.position = position;
    }

}
