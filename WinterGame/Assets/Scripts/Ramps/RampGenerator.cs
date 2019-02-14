using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LevelRampsGenerator
{ levelOne, levelTwo, levelThree, levelFour };


public class RampGenerator : MonoBehaviour
{
    public GameObject[] ramps = new GameObject[8];
    public LevelRampsGenerator gameDifficulty = LevelRampsGenerator.levelOne;

    List<int> randomValues = new List<int>();

    GameObject ramp;

    [HideInInspector]
    public bool levelOne = false;

    int level;

    private void Start()
    {
        SpawnRamps();
    }

    void SpawnRamps()
    {
        level = LevelDifficultSetup(gameDifficulty);
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
        int lastRandomNumber=10;
        for (int i = 0; i < ramps.Length;)
        {
            int rand = Random.Range(0, ramps.Length);
            if(rand != lastRandomNumber && !randomValues.Contains(rand))
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
            ramp = Instantiate(ramps[randomValues[i]]) as GameObject;
        }
    }
}
