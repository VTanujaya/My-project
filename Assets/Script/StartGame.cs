using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private AudioSource button;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        button.Play();
        Debug.Log("A");
        SceneManager.LoadScene("GamePlay");
    }
    public void endGame()
    {
        Application.Quit();
    }
}
