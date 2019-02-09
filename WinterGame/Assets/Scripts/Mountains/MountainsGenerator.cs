using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsGenerator : MonoBehaviour
{

    public GameObject mountainPrefab;
    private GameObject mountain;

    float yPos = 11.9f;

    void Awake()
    {
        GeneratePositionMountain();
    }

    void GeneratePositionMountain()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                GenerateMountain(-46.8f, yPos, -16.985f, 0, 0, 0);
            } else if (i == 1)
            {
                GenerateMountain(-64.2f, yPos, 74.5f, 0, 0, 0);
            }
            else if (i == 2)
            {
                GenerateMountain(-268.9f, yPos, 59.9f, 0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    public void GenerateMountain(float x, float y, float z, float dx, float dy, float dz)
    {
        mountain = Instantiate(mountainPrefab) as GameObject;
        mountain.transform.position = new Vector3(x, y, z);
    }
}
