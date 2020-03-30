using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform pivot;
    public static CameraController cameraController;
    public Camera mainCamera;

    public float panSpeed = 5;
    private float zoomedInAngle = 0;
    private float zoomedOutAngle = 0;
    private float minZoom = 5; 
    private float maxZoom = 200; 
    public bool inverseZoom = false;
    private Vector3 MouseStart, MouseMove;
    private Vector3 derp;
    public static Quaternion currentAngle;

    public float zoomLevel { get; set; }
    float targetPanningX;
    float targetPanningY;
    float targetZoom;
    float targetZoomAngle;
    float targetRotation;

    float currentPanningVelocityX;
    float currentPanningVelocityY;
    float currentZoomVelocity;
    float currentZoomAngleVelocity;
    float currentRotationVelocity;

    float smoothPanningTimeX = 0.3f;
    float smoothPanningTimeY = 0.3f;
    float smoothZoomTime=0.3f;
    float smoothZoomAngleTime = 0.3f;
    float smoothRotationTime = 0.3f;
    // Used before Start()
    void Awake()
    {
        pivot = new GameObject().transform;
        pivot.position = gameObject.transform.position;
        zoomLevel = 0;
        cameraController = this;
        ResetCamera();
    }
    private void Start()
    {
        zoomedInAngle = -45;
        zoomedOutAngle = 0;
        minZoom = 5;
        maxZoom = 200;
    }
    // Update is called once per frame
    void LateUpdate()
    {

        ChangeZoom();
        ChangePosition();
        ChangeRotation();
    }

    // This method pans the camera view in the XZ plane
    void ChangePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = mainCamera.ViewportToWorldPoint(Input.mousePosition);
        }
           else if (Input.GetMouseButton(0))
        {
            MouseMove = mainCamera.ViewportToWorldPoint(Input.mousePosition);
            targetPanningX = transform.position.x - (Input.GetAxis("Mouse X")* transform.up.y + Input.GetAxis("Mouse Y") * transform.up.x)*panSpeed;
            targetPanningY = transform.position.y - (Input.GetAxis("Mouse Y") * transform.right.x+ Input.GetAxis("Mouse X") * transform.right.y) * panSpeed;
            MouseStart = mainCamera.ViewportToWorldPoint(Input.mousePosition);
        }
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, targetPanningX,ref currentPanningVelocityX,smoothPanningTimeX),
            Mathf.SmoothDamp(transform.position.y, targetPanningY, ref currentPanningVelocityY, smoothPanningTimeY),
            gameObject.transform.position.z);
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
            targetZoom = Mathf.Lerp(-minZoom, -maxZoom, zoomLevel);
            targetZoomAngle = Mathf.Lerp(zoomedInAngle, zoomedOutAngle, zoomLevel);
        }
            
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, Mathf.SmoothDamp(mainCamera.transform.localPosition.z,targetZoom,ref currentZoomVelocity,smoothZoomTime));


        mainCamera.transform.localRotation = Quaternion.Euler(
                Mathf.SmoothDampAngle(mainCamera.transform.localRotation.eulerAngles.x,targetZoomAngle, ref currentZoomAngleVelocity, smoothZoomAngleTime),
                mainCamera.transform.localRotation.eulerAngles.y,
                mainCamera.transform.localRotation.eulerAngles.z
                );
            currentAngle = mainCamera.transform.localRotation;

        
    }
    void ChangeRotation() {

        if (Input.GetMouseButton(1))
        {
            targetRotation = transform.eulerAngles.z  + Input.GetAxis("Mouse X") * panSpeed;
            //transform.RotateAround(transform.position, Vector3.up, pos.x);
            //Debug.Log(gameObject.transform.eulerAngles.z.ToString()+targetZoomAngle.ToString());
        }
            gameObject.transform.localRotation = Quaternion.Euler(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            Mathf.SmoothDampAngle(gameObject.transform.eulerAngles.z,  targetRotation, ref currentRotationVelocity, smoothRotationTime));
        currentAngle = gameObject.transform.localRotation;
    }


    // This method resets the camera to the centre of the scene
    public void ResetCamera()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        zoomLevel = 0;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        currentAngle = gameObject.transform.rotation;
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
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
