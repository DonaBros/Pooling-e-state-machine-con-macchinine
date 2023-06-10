using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyRoadLevel : ILevel
{
    protected float carSpeed;
    protected float carSpawnRate;
    protected int carsToNextLevel;


    private GameManager gameManager;

    protected float spawnTimer;
    private float spawnedCarsInThisLevel;

    public BusyRoadLevel(GameManager gm)
    {
        carSpeed = 0.015f;
        carSpawnRate = 1.2f;
        carsToNextLevel = 5;
        gameManager = gm;
        ResetTimer();
    }

    private void ResetTimer()
    {
        // Avvia il timer per lo spawn delle macchine
        spawnTimer = carSpawnRate;
    }


    public ILevel DoLevel()
    {
        SpawnCarIfItsTime();
        if (LevelEnded())
        {
            spawnedCarsInThisLevel = 0;
            return gameManager.baseLevel;
        }
        return this;
    }

    private bool LevelEnded()
    {
        if (spawnedCarsInThisLevel >= carsToNextLevel)
        {
            return true;
        }
        return false;
    }

    private void SpawnCarIfItsTime()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            gameManager.SpawnCar(carSpeed);
            gameManager.SpawnCar(carSpeed);
            spawnedCarsInThisLevel++;
            ResetTimer();
        }

    }
}
