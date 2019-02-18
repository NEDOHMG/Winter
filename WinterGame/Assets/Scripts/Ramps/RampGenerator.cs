using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//public enum LevelRampsGenerator
//{ levelOne, levelTwo, levelThree, levelFour };


public class RampGenerator : MonoBehaviour
{
    public List<RampBlock> allTheRamps = new List<RampBlock>(); // List that contain all the levels
    public List<RampBlock> currentRamps = new List<RampBlock>(); // List of the blocks that are currently displaying

    // public GameObject[] ramps = new GameObject[8];
    //public LevelRampsGenerator gameDifficulty = LevelRampsGenerator.levelOne;

    List<int> randomValues;

    // GameObject ramp;

    [HideInInspector]
    public bool levelOne = false;

    int level;

    public static RampGenerator sharedInstance;

    void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        // SpawnRamps();
    }

    public void SpawnRamps()
    {
        level = LevelDifficultSetup(PlayerSkiController.sharedInstance.gameDifficulty);
        if(level == 1)
        {
            levelOne = true;
        }
        GetNonRepeatRandom();
        GenerateRamp(level * 2);
    }

    int LevelDifficultSetup(LevelRampsGenerator _levelRamps)
    {
        int _level = 0;

        if (_levelRamps == LevelRampsGenerator.levelOne)
        {
            _level = 1;
        }
        else if (_levelRamps == LevelRampsGenerator.levelTwo)
        {
            _level = 2;
        }
        else if (_levelRamps == LevelRampsGenerator.levelThree)
        {
            _level = 3;
        }
        else if (_levelRamps == LevelRampsGenerator.levelFour)
        {
            _level = 4;
        }

        return _level;
    }

    void GetNonRepeatRandom()
    {
        int lastRandomNumber = 10;
        randomValues = new List<int>();

        for (int i = 0; i < allTheRamps.Count;)
        {
            int rand = Random.Range(0, allTheRamps.Count);
            if (rand != lastRandomNumber && !randomValues.Contains(rand))
            {
                randomValues.Add(rand);
                i++;
            }

            lastRandomNumber = rand;
        }
    }

    void GenerateRamp(int position)
    {
        for (int i = 0; i < position; i++)
        {
            RampBlock ramp = Instantiate(allTheRamps[randomValues[i]]);

            // ramp.transform.SetParent(transform, false);

            currentRamps.Add(ramp);
        }
    }

    void RemoveOldRamps()
    {
        // Save the old block in a new object 
        RampBlock ramp = currentRamps[0];
        // Remove the block from the list
        currentRamps.Remove(ramp);
        // Destroy the block
        Destroy(ramp.gameObject);
    }

    public void RemoveAllTheRamps()
    {
        while (currentRamps.Count > 0)
        {
            RemoveOldRamps();
        }
        randomValues = new List<int>();
    }
}
