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
            Debug.Log("Point one passed");
            pointOneTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointTwo") && pointOneTriggered == true && pointTwoTriggered == false && pointThreeTriggered == false)
        {
            Debug.Log("Point two passed");
            pointTwoTriggered = true;
        }
        else if (collider.gameObject.CompareTag("PointThree") && pointOneTriggered == true && pointTwoTriggered == true && pointThreeTriggered == false)
        {
            Debug.Log("Point three passed");
            pointThreeTriggered = true;
        }
    }
}
