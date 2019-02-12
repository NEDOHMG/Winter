using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{

    TriggerSpeed triggerSpeed;
    Rigidbody rb;

    public float speedAdjustment = 1.2f;

    Vector3 speed;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        triggerSpeed = GetComponent<TriggerSpeed>();
        speed = new Vector3(-1.3f, -1.7f, 2.4f);
    }

    void FixedUpdate()
    {

        if (triggerSpeed.pointOneTriggered == false && triggerSpeed.pointTwoTriggered == false && triggerSpeed.pointThreeTriggered == false)
        {
            rb.velocity = speed * speedAdjustment;
            Debug.Log(rb.velocity);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == false && triggerSpeed.pointThreeTriggered == false)
        {
            rb.velocity = speed * speedAdjustment;
            Debug.Log(rb.velocity);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == false)
        {
            rb.velocity = speed * (speedAdjustment + 0.2f);
            Debug.Log(rb.velocity);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true)
        {
            rb.velocity = speed * (speedAdjustment + 1f);
            Debug.Log(rb.velocity);
        }
    }
}
