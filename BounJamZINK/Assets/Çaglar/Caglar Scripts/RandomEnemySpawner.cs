using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] enemyPrefabs;
    private bool canSpawn = true;
    [SerializeField] private float spawnRate = 1.0f;
    private float distanceOfSpawner = 20.0f;
    [SerializeField] private GameObject player;
    void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(changingPositionOfSpawner());
    }

    
    private IEnumerator changingPositionOfSpawner()
    {
        while (true)
        {
            Vector2 randomPosition = new Vector2(Random.Range(player.transform.position.x - distanceOfSpawner, player.transform.position.x + distanceOfSpawner),
                                                    Random.Range(player.transform.position.y - distanceOfSpawner, player.transform.position.y + distanceOfSpawner));

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
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }

   /*private void distanceCalculate()
    {

        Instantiate(spawner, new Vector2(Random.Range(-200, 200), Random.Range(-200, 200)), Quaternion.identity);
        distanceOfSpawner = Vector2.Distance(transform.position, player.transform.position);

        if(distanceOfSpawner == 20.0f)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        

    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
