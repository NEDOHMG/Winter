using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody rb;

    public float impulse = 4f;
    bool jump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (jump)
        {
            UserJump();
        }
    }

    void UserJump()
    {
        rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ramp"))
        {
            Debug.Log("Enter");
            jump = true;
        }
        else
        {
            jump = false;
        }
    }
}
