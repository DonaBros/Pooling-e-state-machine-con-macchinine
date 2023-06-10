using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager_Old : MonoBehaviour
{
    public GameObject carPrefab; // Prefab della macchina
    public int carPoolSize; // Dimensione del pool di macchine

    private List<GameObject> carPool; // Pool di macchine disponibili
    private float spawnTimer; // Timer per il controllo della frequenza di spawn

    [SerializeField] private float roadMaxX = 10f;
    [SerializeField] private float roadMaxY = 4f;

    private int spawnedCarsInThisLevel = 0;
    private int currentLevel = 0;
    [SerializeField] private List<Level_Old> levels = new List<Level_Old>();

    public Level_Old GetCurrentLevel()
    {
        if(currentLevel >= levels.Count)
        {
            return levels.Last();
        }
        return levels[currentLevel];
    }

    private void Start()
    {
        InitializeCarPool();
        ResetTimer();
    }

    public void InitializeCarPool()
    {
        // Inizializza la lista del pool di macchine
        carPool = new List<GameObject>();

        // Riempie il pool di macchine con istanze del prefab
        for (int i = 0; i < carPoolSize; i++)
        {
            GameObject car = Instantiate(carPrefab);
            car.SetActive(false);
            carPool.Add(car);
        }
    }

    private void ResetTimer()
    {
        // Avvia il timer per lo spawn delle macchine
        spawnTimer = GetCurrentLevel().CarSpawnRate();
    }

    private void Update()
    {
        SpawnCarIfItsTime();
    }

    private void SpawnCarIfItsTime()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnCar();
            ResetTimer();
        }
    }

    private void SpawnCar()
    {
        // Cerca una macchina inattiva nel pool
        GameObject car = carPool.Find(c => !c.activeInHierarchy);

        // Se non ci sono macchine disponibili nel pool, esci dalla funzione
        if (car == null)
            return;

        // Posiziona la macchina in una posizione casuale sulla strada
        car.transform.position = GetRandomSpawnPosition();
        car.GetComponent<Car>().SetSpeed(GetCurrentLevel().CarSpeed());
        car.SetActive(true);

        CheckIfLevelChanged();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnY = Random.Range(-roadMaxY, roadMaxY);
        float spawnX = roadMaxX;

        return new Vector3(spawnX, spawnY, 0f);
    }

    public void CheckIfLevelChanged()
    {
        spawnedCarsInThisLevel++;

        if(spawnedCarsInThisLevel >= GetCurrentLevel().CarsToNextLevel())
        {
            ChangeLevel();
        }
    }

    public void ChangeLevel()
    {
        currentLevel++;
        spawnedCarsInThisLevel = 0;
        Debug.Log("New Level! Level "+currentLevel);
    }
}
