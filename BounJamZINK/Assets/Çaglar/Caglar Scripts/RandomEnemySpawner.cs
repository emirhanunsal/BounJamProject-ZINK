using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] enemyPrefabs;
    private bool canSpawn = true;
    private float spawnRate = 1f;
    [SerializeField] public float distanceOfSpawner = 20.0f;
     private GameObject player;
     public static int enemyCount  = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Spawner());
        StartCoroutine(changingPositionOfSpawner());
    }

    private IEnumerator changingPositionOfSpawner()
    {
        while (true)
        {

            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;

            Vector3 randomPosition = player.transform.position + new Vector3(randomDirection.x, randomDirection.y, 0) * distanceOfSpawner;

            transform.position = randomPosition;

            yield return new WaitForSeconds(spawnRate);
        }
    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            if (enemyCount < 200)
            {
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                enemyCount++;
            }
        }
    }

    private float timer = 0f;
    float maxTimer = 25f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            if ((spawnRate = spawnRate - 0.05f) >= 0.05f)
            {
                spawnRate = spawnRate - 0.05f;
            }
            else
            {
                spawnRate = 0.05f;
            }
        }
    }
}
