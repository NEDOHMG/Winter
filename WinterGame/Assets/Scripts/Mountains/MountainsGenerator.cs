using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsGenerator : MonoBehaviour
{

    public GameObject mountainsPrefab;
    private GameObject mountains;

    void Awake()
    {
        GenerateMountains(-439.011f, 23.75f, 253.5f);
    }


    // Update is called once per frame
    void GenerateMountains(float x, float y, float z)
    {
        mountains = Instantiate(mountainsPrefab) as GameObject;
        mountains.transform.position = new Vector3(x, y, z);
    }
}
