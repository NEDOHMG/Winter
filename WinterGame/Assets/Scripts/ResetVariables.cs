using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    public static ResetVariables sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    public void ResetTheGameVariables()
    {
        // Ramp generator
        RampGenerator.sharedInstance.levelOne = false;

        // Player jump
        PlayerJump.sharedInstance.firstJump = true;
        PlayerJump.sharedInstance.jump = false;

        // Rotation point
        RotationPoint.sharedInstance.speedAceleration = 1.3f;

        // Camera triggers
        CameraTriggerRotations.sharedInstance.cameraRotationX = false;
        CameraTriggerRotations.sharedInstance.cameraRotationY = false;
        CameraTriggerRotations.sharedInstance.cameraRotationZ = false;
        CameraTriggerRotations.sharedInstance.cameraFieldView = false;

        // Trigger speed
        TriggerSpeed.sharedInstance.pointOneTriggered = false;
        TriggerSpeed.sharedInstance.pointTwoTriggered = false;
        TriggerSpeed.sharedInstance.pointThreeTriggered = false;
        TriggerSpeed.sharedInstance.goal = false;
        TriggerSpeed.sharedInstance.stop = false;
        TriggerSpeed.sharedInstance.speedAcelerator = false;
    }
}
