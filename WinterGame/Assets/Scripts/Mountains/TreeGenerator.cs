using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

    public GameObject treePineType;
    private GameObject treeTypeOne;


    void Awake()
    {

    }

    // Update is called once per frame
    public void GeneratePositionMonsterOne()
    {
        treeTypeOne = Instantiate(treePineType) as GameObject;
        treeTypeOne.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.633f, Random.Range(-5.0f, 5.0f));
    }
}
