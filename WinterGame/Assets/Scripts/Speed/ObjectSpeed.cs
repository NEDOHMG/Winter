using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{
    const float x = -1.3f, y = -1.7f, z = 2.4f;

    TriggerSpeed triggerSpeed;
    public Rigidbody rb;

    public float speedAdjustmentAceleration = 0.7f;

    Vector3 speed;
    Vector3 desVec;


    // Use this for initialization
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        triggerSpeed = GetComponent<TriggerSpeed>();
        speed = new Vector3(x, y, z);
        //desVec = speed = new Vector3(speedAdjustmentDesaceleration, speedAdjustmentDesaceleration, speedAdjustmentDesaceleration);
    }

    void FixedUpdate()
    {
        if(triggerSpeed.stop)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            rb.mass = 0.0f;
        }

        if (triggerSpeed.pointOneTriggered == false && triggerSpeed.pointTwoTriggered == false && triggerSpeed.pointThreeTriggered == false && triggerSpeed.goal == false)
        {
            rb.velocity = speed * speedAdjustmentAceleration;
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == false && triggerSpeed.pointThreeTriggered == false && triggerSpeed.goal == false)
        {
            rb.velocity = speed * (speedAdjustmentAceleration + 0.1f);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == false && triggerSpeed.goal == false)
        {
            rb.velocity = speed * (speedAdjustmentAceleration + 0.05f);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true && triggerSpeed.goal == false)
        {
            rb.velocity = speed * speedAdjustmentAceleration;
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true && triggerSpeed.goal == true)
        {
            //speedAdjustmentAceleration = 0.2f;
            //rb.velocity = speed * speedAdjustmentAceleration;
        }
    }
}
