using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingRight : MonoBehaviour
{
    public static ObjectPoolingRight SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private int index;
    private spawner spawner;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
            Invoke("Spawn", 3f);
    }
        // Update is called once per frame
        void Update()
    {
    }
    public GameObject getPooledObject()
        {
            for(int i = 0; i < amountToPool; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    void Spawn()
    {
        float spawnInterval = Random.Range(0.5f, 2f);
        Vector3 spawnLocation = new Vector3(Random.Range(90,150), Random.Range(367, 377), 1545);
        GameObject tree = ObjectPooling.SharedInstance.getPooledObject();
        if (tree != null)
        {
            tree.transform.position = spawnLocation;
            tree.SetActive(true);
        }
        index++;
        Invoke("Spawn", spawnInterval);
    }
}
