using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    private float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime * 2, Space.World);
        if(transform.position.z < 0 && gameObject.CompareTag("Tree") == false)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < 0 && gameObject.CompareTag("Tree") == true)
        {
            gameObject.SetActive(false);
        }
    }
}
