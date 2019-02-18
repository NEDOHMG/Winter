using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkiController : MonoBehaviour
{
    //[HideInInspector]
    public bool StartGame = false;

    public static PlayerSkiController sharedInstance;

    void Start()
    {
        sharedInstance = this;
    }
}
