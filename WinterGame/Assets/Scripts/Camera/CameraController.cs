using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float yOffset = 0.32f;

    GameObject startPoint;
    CameraTriggerRotations cameraTriggerRotations;

    GameObject ramp;
    RampGenerator rampGenerator;

    Vector3 originalRotation;
    Vector3 rotateValue;
    bool lookAt = false;
    float xi = 0.01f;
    float yi;
    float zi;



    [HideInInspector]
    public float xOffset = 0.0f, zOffset = 0.0f;

    private Vector3 totalOffSet;

    //This is the field of view that the Camera has
    Camera _camera;

    // Use this for initialization
    void Start()
    {
        totalOffSet = new Vector3(xOffset, yOffset, zOffset);
        startPoint = GameObject.FindGameObjectWithTag("Player");
        cameraTriggerRotations = startPoint.GetComponent<CameraTriggerRotations>();
        originalRotation = transform.rotation.eulerAngles;
        rotateValue = originalRotation;
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = 20f;

        ramp = GameObject.Find("RampSpotGenerator");
        rampGenerator = ramp.GetComponent<RampGenerator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position + totalOffSet;

        if (cameraTriggerRotations.cameraRotationX == true)
        {
            xi += 0.025f;

            if (rotateValue.y < 364.0f && cameraTriggerRotations.cameraRotationY == true)
            {
                yi += 0.03f;
                rotateValue.y = originalRotation.y + yi;
            }
            else if (rotateValue.y > 364.0f && cameraTriggerRotations.cameraRotationY == false)
            {
          
                rotateValue.y = 364.30f;
            }

            if (rotateValue.z <= 360f && cameraTriggerRotations.cameraRotationZ == true)
            {
                zi += 0.001f;
            }
            else
            {
                zi = 0;
            }

            if (rotateValue.x > -5.9f)
            {
                //Debug.Log("x: " + rotateValue.x + " y: " + rotateValue.y + " z: " + rotateValue.z);
                rotateValue.x = originalRotation.x - xi;
                // rotateValue.y = originalRotation.y + yi;
                rotateValue.z = originalRotation.z + zi;
                transform.eulerAngles = rotateValue;
            }
        }

        if (cameraTriggerRotations.cameraFieldView == true)
        {

            if(rampGenerator.levelOne == true && _camera.fieldOfView < 65)
            {
                _camera.fieldOfView += 0.05f;
            }
            else if (_camera.fieldOfView < 65)
            {
                _camera.fieldOfView += 0.02f;
            }
        }

        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
    }
}
