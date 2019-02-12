using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{

    TriggerSpeed triggerSpeed;
    Rigidbody rb;

    [HideInInspector]
    public float speedConstantObject = 0.5f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        triggerSpeed = GetComponent<TriggerSpeed>();
    }

    void FixedUpdate()
    {
        if (triggerSpeed.pointOneTriggered == false && triggerSpeed.pointOneTriggered == false && triggerSpeed.pointOneTriggered == false)
        {
            rb.AddTorque(new Vector3(triggerSpeed.speedUpdated * speedConstantObject, 0.0f, triggerSpeed.speedUpdated * speedConstantObject) * speedConstantObject * Time.deltaTime);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointOneTriggered == false && triggerSpeed.pointOneTriggered == false)
        {
            rb.AddTorque(new Vector3(triggerSpeed.speedUpdated * speedConstantObject, 0.0f, triggerSpeed.speedUpdated * speedConstantObject) * speedConstantObject * Time.deltaTime);
        }
        else if (triggerSpeed.pointOneTriggered == true && triggerSpeed.pointOneTriggered == true && triggerSpeed.pointOneTriggered == false)
        {
            speedConstantObject = 10f;
            rb.AddTorque(new Vector3(triggerSpeed.speedUpdated * speedConstantObject, 0.0f, triggerSpeed.speedUpdated * speedConstantObject) * speedConstantObject * Time.deltaTime);
        }
    }
}
