using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level_Old
{
    [SerializeField] private float carSpeed;
    [SerializeField] private float carSpawnRate;
    [SerializeField] private int carsToNextLevel;

    public float CarSpeed()
    {
        return carSpeed;
    }

    public float CarSpawnRate()
    {
        return carSpawnRate;
    }

    public int CarsToNextLevel()
    {
        return carsToNextLevel;
    }
}

