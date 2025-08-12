using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Pepe Settings")]
    [SerializeField] private float startSpawnInterval = 1.5f;
    [SerializeField] private float minSpawnInterval = 0.9f;
    [SerializeField] private float timeToMinInterval = 60f; // Thời gian để giảm dần đến min (giây)

    private float spawnInterval;
    private float timer;
    private float elapsedTime;

    private bool isSpawning = true; // Biến kiểm soát trạng thái spawn

    private void Start()
    {
        spawnInterval = startSpawnInterval;
    }

    private void Update()
    {
        if (!isSpawning) return;

        elapsedTime += Time.deltaTime;

        // Giảm dần thời gian spawn theo thời gian
        float t = Mathf.Clamp01(elapsedTime / timeToMinInterval);
        spawnInterval = Mathf.Lerp(startSpawnInterval, minSpawnInterval, t);

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnPepe();
        }
    }

    private void SpawnPepe()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x = Random.Range(-1.8f, 1.8f);

        SimplePool.Spawn<Food>(PoolType.FoodSpawned, spawnPos, Quaternion.identity);
    }

    // 📌 Hàm dừng spawn
    public void Stop()
    {
        isSpawning = false;

        SimplePool.CollectAll();
    }

    // 📌 Hàm tiếp tục spawn
    public void Continue()
    {
        isSpawning = true;
    }
}
