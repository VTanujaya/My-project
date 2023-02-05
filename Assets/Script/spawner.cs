using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnInterval = 0.5f;
    public int maxInterval = 6;
    public int minInterval = 3;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
            Invoke("Spawn", spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
            spawnInterval = Random.Range(minInterval, maxInterval);
            int indexObstacle = Random.Range(0, 11);
        if (indexObstacle < 8)
        {
            indexObstacle = 0;
        }else
        {
            indexObstacle = 1;
        }
            Vector3 spawnLocation = new Vector3(Random.Range(-16, 16), obstaclePrefab[indexObstacle].transform.position.y, 1200);
            Instantiate(obstaclePrefab[indexObstacle], spawnLocation, obstaclePrefab[indexObstacle].transform.rotation);
            Invoke("Spawn", spawnInterval);
    }
}
