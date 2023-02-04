using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnInterval = 0.5f;
    public int maxInterval = 6;
    public int minInterval = 3;
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
        spawnInterval = Random.Range(minInterval,maxInterval);
        Vector3 spawnLocation = new Vector3(Random.Range(-16, 16), 395, 1200);
        int indexObstacle = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[indexObstacle],spawnLocation, obstaclePrefab[indexObstacle].transform.rotation);
        Invoke("Spawn", spawnInterval);
        
    }
}
