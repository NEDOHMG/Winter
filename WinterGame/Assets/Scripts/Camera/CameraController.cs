using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float yOffset = 0.32f;

    GameObject startPoint;
    RotationPointOne rotationPointOne;
    Vector3 originalRotation;
    Vector3 rotateValue;
    float i = 0.01f;

    [HideInInspector]
    public float xOffset = 0.0f, zOffset = 0.0f;
    private Vector3 totalOffSet;

    [HideInInspector]
    public bool lookAt = true;

    // Use this for initialization
    void Start ()
    {
        totalOffSet = new Vector3(xOffset, yOffset, zOffset);
        startPoint = GameObject.FindGameObjectWithTag("Player");
        rotationPointOne = startPoint.GetComponent<RotationPointOne>();
        originalRotation = transform.rotation.eulerAngles;
        rotateValue = originalRotation;
    }

	// Update is called once per frame
	void FixedUpdate() {

        transform.position = target.transform.position + totalOffSet;

        if(rotationPointOne.cameraRotation == true && rotateValue.x > -1.5f)
        {
            i += 0.06f;
            Debug.Log("Change the angle");
            Debug.Log(originalRotation);
            rotateValue = new Vector3(originalRotation.x - i, originalRotation.y, originalRotation.z);
            transform.eulerAngles =  rotateValue;
        }

        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
	}
}
