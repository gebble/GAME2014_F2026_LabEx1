using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int poolSize = 5;

    [SerializeField]
    private float spawnInterval = 1.5f;

    private List<EnemyBehavior> pool;
    private float spawnTimer;

    void Start()
    {
        
        pool = new List<EnemyBehavior>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, transform);
            obj.SetActive(false); 
            pool.Add(obj.GetComponent<EnemyBehavior>());
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemyFromPool();
        }
    }

    private void SpawnEnemyFromPool()
    {
        
        foreach (EnemyBehavior enemy in pool)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                enemy.Spawn();
                return;
            }
        }
    }
}