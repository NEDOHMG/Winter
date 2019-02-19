using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{

    public static ResetLevel sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    public void ResetThePlayersMethods()
    {
        StartCoroutine(ExecuteAfterTime(1));
        StartCoroutine(WaitForPlayer(3));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        ObjectSpeed.sharedInstance.ResetPositionSpeedUser();
        CameraController.sharedInstance.ResetCamera();
    }

    public IEnumerator WaitForPlayer(float time)
    {
        yield return new WaitForSeconds(time);
        TriggerSpeed.sharedInstance.stop = false; // This is a probe
        PlayerSkiController.sharedInstance.startGame = true;
        ObjectSpeed.sharedInstance.rb.isKinematic = false;
    }

}
