using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float xOffset = 0.0f;
    public float yOffset = 0.32f;
    public float zOffset = 0.0f;
    public bool lookAt = false;
    private Vector3 totalOffSet;

	// Use this for initialization
	void Start ()
    {
        totalOffSet = new Vector3(xOffset, yOffset, zOffset);
    }

	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.transform.position + totalOffSet;
        if (lookAt)
        {
            transform.LookAt(target.transform.position);
        }
	}
}
