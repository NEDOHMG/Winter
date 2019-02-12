using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeed : MonoBehaviour
{
    Rigidbody rb;

    [HideInInspector]
    public float speedUpdated;
    [HideInInspector]
    public bool pointOneTriggered = false, pointTwoTriggered = false, pointThreeTriggered = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PointOne") && pointOneTriggered == false && pointTwoTriggered == false && pointThreeTriggered == false)
        {
            Debug.Log("Point one passed");
            speedUpdated = 0.25f;
            pointOneTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointTwo") && pointTwoTriggered == false)
        {
            Debug.Log("Point two passed");
            speedUpdated = 0.4f;
            pointTwoTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointThree") && pointThreeTriggered == false)
        {
            Debug.Log("Point three passed");
            speedUpdated = 2f;
            pointThreeTriggered = true;
        }
    }
}
