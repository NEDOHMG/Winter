using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float yOffset = 0.32f;

    [HideInInspector]
    public float xOffset = 0.0f, zOffset = 0.0f;
    private Vector3 totalOffSet;

    [HideInInspector]
    public bool lookAt = true;

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
