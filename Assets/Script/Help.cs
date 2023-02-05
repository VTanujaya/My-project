using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpScreen;
    private bool show;
    // Start is called before the first frame update
    void Start()
    {
        show = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPress()
    {
        if (!show)
        {
            helpScreen.SetActive(true);
            show= true;
        }
        else
        {
            helpScreen.SetActive(false);
            show= false;
        }
    }
}
