using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float yOffset = 0.32f;

    GameObject startPoint;
    RotationPointOne rotationPointOne;
    Vector3 originalRotation;
    Vector3 rotateValue;
    bool lookAt = false;
    float i = 0.01f;


    [HideInInspector]
    public float xOffset = 0.0f, zOffset = 0.0f;

    private Vector3 totalOffSet;

    //This is the field of view that the Camera has
    Camera camera;

    // Use this for initialization
    void Start()
    {
        totalOffSet = new Vector3(xOffset, yOffset, zOffset);
        startPoint = GameObject.FindGameObjectWithTag("Player");
        rotationPointOne = startPoint.GetComponent<RotationPointOne>();
        originalRotation = transform.rotation.eulerAngles;
        rotateValue = originalRotation;
        camera = GetComponent<Camera>();
        camera.fieldOfView = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position + totalOffSet;

        if (rotationPointOne.cameraRotationX == true)
        {
            i += 0.06f;
            // Debug.Log("Change the angle");
            // Debug.Log(originalRotation);
            if (rotateValue.x > -1.7f)
            {
                rotateValue = new Vector3(originalRotation.x - i, originalRotation.y, originalRotation.z);
                transform.eulerAngles = rotateValue;
            }
        }

        if (rotationPointOne.cameraFieldView== true)
        {
            Debug.Log("Enter");
            if (camera.fieldOfView < 65)
            {
                camera.fieldOfView += 0.08f;
            }
        }

        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
    }
}
