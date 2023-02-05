using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public bool turbo1;
    public bool turbo2;
    private float speedUp;
    private points point;
    public Button[] buy;
    public AudioSource button;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("Player").GetComponent<points>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buyTurbo1()
    {
        Debug.Log(point.getPoint());
        if (point.getPoint()>50)
        {
            button.Play();
            point.addScore(-50, 0);
            turbo1 = true;
            buy[0].enabled = false;
        }
    }
    public void buyTurbo2()
    {
        if (point.getPoint()>50)
        {
            button.Play();
            point.addScore(-50, 0);
            turbo2 = true;
            buy[1].enabled = false;
        }
    }
}
