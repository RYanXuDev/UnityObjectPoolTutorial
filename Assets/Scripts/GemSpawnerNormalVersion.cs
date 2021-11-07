using UnityEngine;

public class GemSpawnerNormalVersion : MonoBehaviour
{
    [SerializeField] Gem[] gemPrefabs;
    [SerializeField] int spawnAmount = 50;
    [SerializeField] float spawnInterval = 0.5f;

    float spawnTimer;

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
            var prefab = gemPrefabs[randomIndex];
            var gem = Instantiate(prefab, transform);

            gem.transform.position = transform.position + Random.insideUnitSphere * 2f;
            gem.SetDeactivateAction(delegate { Destroy(gem.gameObject); });
        }
    }
}