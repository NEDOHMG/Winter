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
    Camera _camera;

    // Use this for initialization
    void Start()
    {
        totalOffSet = new Vector3(xOffset, yOffset, zOffset);
        startPoint = GameObject.FindGameObjectWithTag("Player");
        rotationPointOne = startPoint.GetComponent<RotationPointOne>();
        originalRotation = transform.rotation.eulerAngles;
        rotateValue = originalRotation;
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = 20f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position + totalOffSet;

        if (rotationPointOne.cameraRotationX == true)
        {
            i += 0.06f;
            if (rotateValue.x > -5.9f)
            {
                rotateValue = new Vector3(originalRotation.x - i, originalRotation.y, originalRotation.z);
                transform.eulerAngles = rotateValue;
            }
        }

        if (rotationPointOne.cameraFieldView== true)
        {
            if (_camera.fieldOfView < 65)
            {
                _camera.fieldOfView += 0.08f;
            }
        }

        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
    }
}
