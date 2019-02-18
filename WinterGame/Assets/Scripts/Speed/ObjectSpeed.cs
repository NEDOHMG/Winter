using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{
    const float x = -1.3f, y = -1.7f, z = 2.4f;

    public Rigidbody rb;

    TriggerSpeed triggerSpeed;
    PlayerJump playerJump;

    GameObject ramp;
    RampGenerator rampGenerator;

    public float speedAdjustmentAceleration = 0.4f;

    Vector3 speed;
    Vector3 desVec;

    // Use this for initialization
    void Start()
    {
        triggerSpeed = GetComponent<TriggerSpeed>();
        playerJump = GetComponent<PlayerJump>();

        ramp = GameObject.Find("RampSpotGenerator");
        rampGenerator = ramp.GetComponent<RampGenerator>();

        speed = new Vector3(x, y, z);

    }

    public void InTheGame()
    {
        if (triggerSpeed.stop)
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
            if (rampGenerator.levelOne)
            {
                speedAdjustmentAceleration = 0.5f;
                // rb.AddForce(rotationXPoint * speedAceleration, 0, rotationZPoint * speedAceleration * Time.deltaTime, ForceMode.Impulse);
                rb.AddForce(0.05f * 1.3f, 0, 0.1f * 1.3f, ForceMode.Impulse);
                rb.velocity = speed * (speedAdjustmentAceleration + 0.12f);
            }
            rb.velocity = speed * (speedAdjustmentAceleration + 0.05f);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true && triggerSpeed.goal == false && triggerSpeed.speedAcelerator == true && playerJump.jump == true)
        {

            rb.velocity = speed * (speedAdjustmentAceleration + 0.12f);

        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true && triggerSpeed.goal == false)
        {
            rb.velocity = speed * speedAdjustmentAceleration;
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointTwoTriggered == true && triggerSpeed.pointThreeTriggered == true && triggerSpeed.goal == true)
        {
            // It will start to desacelerate
        }
    }

    void FixedUpdate()
    {
        if (PlayerSkiController.sharedInstance.StartGame)
        {
            rb.isKinematic = false;
        }
        InTheGame();
    }

}
