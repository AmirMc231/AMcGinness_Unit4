using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMangager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 8.5f;
    private int enemyCount;

    private int spawnNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 spawnpos2 = GenerateSpawnPosition();

        SpawnWave(5);

    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyBehavior>().Length;
        if(enemyCount == 0)
        {
            SpawnWave(spawnNumber);
            //++spawnNumber;
            spawnNumber = spawnNumber + 2;
        }
    }

    void SpawnWave(int enemyNum)
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        for(int i = 0; i < enemyNum; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnpos = new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
        return spawnpos;
    }

    
}
