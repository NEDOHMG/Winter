using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPoint : MonoBehaviour
{

    Rigidbody rb;

    [HideInInspector]
    public float speedAceleration = 1.3f;

    public static RotationPoint sharedInstance;

    bool rotateTrigger = false;
    bool rotSpeedBoost = false;

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
            Debug.Log("Rotate One");
            rotateTrigger = true;
            // rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointTwo"))
        {
            rotateTrigger = true;
            Debug.Log("Rotate Two");
            // rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointThree"))
        {
            rotateTrigger = true;
            Debug.Log("Rotate Three");
            // rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (collider.gameObject.CompareTag("RotatePointFour"))
        {
            rotateTrigger = true;
            rotSpeedBoost = true;
            Debug.Log("Rotate Four");
            speedAceleration = speedAceleration + 0.02f;
            // rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint * speedAceleration, 0, PlayerSkiController.sharedInstance.rotationZPoint * speedAceleration * Time.deltaTime, ForceMode.Impulse);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("RotatePointOne"))
        {
            Debug.Log("Rotate One Exit");
            rotateTrigger = false;

        }
        else if (collider.gameObject.CompareTag("RotatePointTwo"))
        {
            Debug.Log("Rotate Two");
            rotateTrigger = false;
        }
        else if (collider.gameObject.CompareTag("RotatePointThree"))
        {
            Debug.Log("Rotate Three");
            rotateTrigger = false;
        }
        else if (collider.gameObject.CompareTag("RotatePointFour"))
        {
            Debug.Log("Rotate Four");
            rotateTrigger = false;
            rotSpeedBoost = false;
        }
    }

    void FixedUpdate()
    {
        if (rotateTrigger)
        {
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint, 0, PlayerSkiController.sharedInstance.rotationZPoint, ForceMode.Impulse);
        }
        else if (rotateTrigger == true && rotSpeedBoost == true)
        {
            rb.AddForce(PlayerSkiController.sharedInstance.rotationXPoint * speedAceleration, 0, PlayerSkiController.sharedInstance.rotationZPoint * speedAceleration * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
