using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private float spawnChanse = 0.4f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new (spawnRate);
        while (canSpawn)
        {
            yield return wait;

            int randChanse = Random.Range(0, 1);
            if (randChanse < spawnChanse)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = enemyPrefabs[rand];

                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }
    }
}
