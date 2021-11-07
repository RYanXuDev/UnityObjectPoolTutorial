using System.Collections.Generic;
using UnityEngine;

public class GemSpawnerPoolVersion : MonoBehaviour
{
    [SerializeField] Gem[] gemPrefabs;
    [SerializeField] int spawnAmount = 50;
    [SerializeField] float spawnInterval = 0.5f;

    float spawnTimer;

    List<GemPool> gemPools = new List<GemPool>();

    void Start()
    {
        foreach (var prefab in gemPrefabs)
        {
            var poolHolder = new GameObject($"Pool: {prefab.name}");

            poolHolder.transform.parent = transform;
            poolHolder.transform.position = transform.position;
            poolHolder.SetActive(false);

            var pool = poolHolder.AddComponent<GemPool>();
            
            pool.SetPrefab(prefab);
            poolHolder.SetActive(true);
            gemPools.Add(pool);
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            var randomIndex = Random.Range(0, gemPrefabs.Length);
            var pool = gemPools[randomIndex];
            pool.Get();
        }
    }
}