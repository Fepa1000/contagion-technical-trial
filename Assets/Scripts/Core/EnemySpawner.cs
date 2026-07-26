using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public int normalCount;
    public int fastCount;
    public int tankCount;

    public int TotalEnemies => normalCount + fastCount + tankCount;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;

    [Header("Enemy Prefabs")]
    public GameObject enemyPrefab;
    public GameObject enemyFastPrefab;
    public GameObject enemyTankPrefab;

    private Wave[] waves;
    private int currentWaveIndex = 0;

    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private int enemiesKilledThisWave = 0;
    private float timer = 0f;

    private void Start()
    {
        GameManager.Instance.OnKillCountChanged += OnEnemyKilled;

        waves = new Wave[3];
        waves[0] = new Wave { normalCount = 10, fastCount = 0, tankCount = 0 }; // 10 total enemies
        waves[1] = new Wave { normalCount = 8, fastCount = 6, tankCount = 1 };  // 15 total enemies
        waves[2] = new Wave { normalCount = 10, fastCount = 5, tankCount = 5 }; // 20 total enemies

        StartWave();
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnKillCountChanged -= OnEnemyKilled;
        }
    }

    private void Update()
    {
        if (player == null || currentWaveIndex >= waves.Length) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval && enemiesToSpawn.Count > 0)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void StartWave()
    {
        enemiesKilledThisWave = 0;
        enemiesToSpawn.Clear();

        Wave currentWave = waves[currentWaveIndex];

        for (int i = 0; i < currentWave.normalCount; i++) enemiesToSpawn.Add(enemyPrefab);
        for (int i = 0; i < currentWave.fastCount; i++) enemiesToSpawn.Add(enemyFastPrefab);
        for (int i = 0; i < currentWave.tankCount; i++) enemiesToSpawn.Add(enemyTankPrefab);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemiesToSpawn.Count);
        GameObject enemyToSpawn = enemiesToSpawn[randomIndex];

        enemiesToSpawn.RemoveAt(randomIndex);

        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    }

    void OnEnemyKilled()
    {
        enemiesKilledThisWave++;

        if (currentWaveIndex < waves.Length && enemiesKilledThisWave >= waves[currentWaveIndex].TotalEnemies)
        {
            currentWaveIndex++;

            if (currentWaveIndex < waves.Length)
            {
                StartWave();
                Debug.Log("Start of Wave " + (currentWaveIndex + 1));
            }
            else
            {
                Debug.Log("You win!");
            }
        }
    }
}