using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPointOne : MonoBehaviour {

    Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("RotatePointOne"))
        {

            transform.Rotate(0f, 90, 0f);
        }
    }
}
