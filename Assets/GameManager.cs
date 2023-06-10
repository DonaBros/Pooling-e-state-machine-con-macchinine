using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab; // Prefab della macchina
    public int carPoolSize; // Dimensione del pool di macchine

    private List<GameObject> carPool; // Pool di macchine disponibili

    [SerializeField] private float roadMaxX = 10f;
    [SerializeField] private float roadMaxY = 4f;

    public BaseRoadLevel baseLevel;
    public BusyRoadLevel busyLevel;

    private ILevel currentLevel;


    private void Start()
    {
        baseLevel = new BaseRoadLevel(this);
        busyLevel = new BusyRoadLevel(this);
        InitializeCarPool();
        currentLevel = baseLevel;
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


    private void Update()
    {
        currentLevel = currentLevel.DoLevel();
    }

    public void SpawnCar(float carspeed)
    {
        // Cerca una macchina inattiva nel pool
        GameObject car = carPool.Find(c => !c.activeInHierarchy);

        // Se non ci sono macchine disponibili nel pool, esci dalla funzione
        if (car == null)
            return;

        // Posiziona la macchina in una posizione casuale sulla strada
        car.transform.position = GetRandomSpawnPosition();
        car.GetComponent<EnemyCar>().SetSpeed(carspeed);
        car.SetActive(true);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnY = Random.Range(-roadMaxY, roadMaxY);
        float spawnX = roadMaxX;

        return new Vector3(spawnX, spawnY, 0f);
    }
}
