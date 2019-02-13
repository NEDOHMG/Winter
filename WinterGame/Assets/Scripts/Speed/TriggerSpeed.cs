using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeed : MonoBehaviour
{

    [HideInInspector]
    public bool pointOneTriggered = false, pointTwoTriggered = false, pointThreeTriggered = false;

    public void OnTriggerEnter(Collider collider)
    {
        // This is the normal state of the game before enter in any trigger
        if (collider.gameObject.CompareTag("PointOne") && pointOneTriggered == false && pointTwoTriggered == false && pointThreeTriggered == false)
        {
            pointOneTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointTwo") && pointOneTriggered == true && pointTwoTriggered == false && pointThreeTriggered == false)
        {
            pointTwoTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointThree") && pointOneTriggered == true && pointTwoTriggered == true && pointThreeTriggered == false)
        {
            pointThreeTriggered = true;
        }
    }
}
