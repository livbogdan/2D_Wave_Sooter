using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {

    [System.Serializable]
    public class Wave 
    {
        [Header("Enemies")]
        
        public GameObject[] enemies;
        public int count;
        public float timeBetweenSpawns;        
                
    }

    [Header("Enemy Spawn Configuration")]
    
    public Wave[] waves;
    [Space]
    public Transform[] spawnPoints;
    [Space]
    public float timeBetweenWaves;
    

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    private bool spawningFinished;

    [Header("Boss Configuration")]
    public GameObject boss;
    public Transform bossSpawnPoint;
    public GameObject healthBar;

    [Header("Text")]
    public TextMeshProUGUI waveText;    
    


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(CallNextWave(currentWaveIndex));
    }

    private void Update()
    {
      
        if (spawningFinished == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
            {
                spawningFinished = false;
                if (currentWaveIndex + 1 < waves.Length)
                {
                   currentWaveIndex++;
                   StartCoroutine(CallNextWave(currentWaveIndex));
                   

                }
                else
                {
                Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                healthBar.SetActive(true);

                }

            }

        waveText.text = "Wave " + currentWaveIndex.ToString();
        
    }

    IEnumerator CallNextWave(int waveIndex) {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(waveIndex));
    }

    IEnumerator SpawnWave (int waveIndex) {
        currentWave = waves[waveIndex];

        for (int i = 0; i < currentWave.count; i++)
        {

            if (player == null)
            {
                yield break;
            }
            GameObject randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, transform.rotation);

            if (i == currentWave.count - 1)
            {
                spawningFinished = true;
                
            }
            else
            {
                spawningFinished = false;
                
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);

        }


    }

}
