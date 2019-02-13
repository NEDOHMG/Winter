using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPointOne : MonoBehaviour
{

    public Rigidbody rb;

    GameObject playerCamera;
    CameraController cameraController;

    public float rotationXPoint = 0.01f;
    public float rotationZPoint = 0.5f;

    bool _rotate = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
        cameraController = playerCamera.GetComponent<CameraController>();

    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("RotatePointOne") && _rotate == true)
        {
            rb.AddForce(rotationXPoint, 0, rotationZPoint, ForceMode.Impulse);
            _rotate = false;
        }
        else if (collider.gameObject.CompareTag("RotatePointTwo") && _rotate == false)
        {
            rb.AddForce(rotationXPoint, 0, rotationZPoint, ForceMode.Impulse);
        }
    }
}
