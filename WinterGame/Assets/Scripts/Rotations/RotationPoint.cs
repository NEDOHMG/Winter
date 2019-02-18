using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPoint : MonoBehaviour
{

    Rigidbody rb;

    //public float rotationXPoint = 0.05f;
    //public float rotationZPoint = 0.1f;

    //[HideInInspector]
    //public bool cameraRotationX = false, cameraFieldView = false;

    [HideInInspector]
    public float speedAceleration = 1.3f;

    public static RotationPoint sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("RotatePointOne"))
        {
            // Debug.Log("rotateOne");
            //cameraRotationX = true;
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointTwo"))
        {
            //Debug.Log("rotateTwo");
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointThree"))
        {
            //Debug.Log("rotateThree");
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointFour"))
        {
            //Debug.Log("rotateFour");
            //cameraFieldView = true;
            speedAceleration = speedAceleration + 0.02f;
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint * speedAceleration, 0, PlayerSkiController.sharedInstance.rotationZPoint * speedAceleration * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
