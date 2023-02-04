using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveArea : MonoBehaviour
{
    public float speed = 100f;
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = transform.localScale.z/2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime*2, Space.World);
        if(transform.position.z-repeatWidth/2 < repeatWidth - startPos.z)
        {
            transform.position = startPos; 
        }
    }
}
