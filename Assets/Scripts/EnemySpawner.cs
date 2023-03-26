using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    public int enemiesCount;
    public int waveNumber = 1;

    private float spawnRange = 9f;
    void Start()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        if(enemiesCount == 0)
        {
            waveNumber++;
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }

    private void SpawnEnemyWave(int enemiesTospawn)
    {
        for (int i = 0; i < enemiesTospawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
