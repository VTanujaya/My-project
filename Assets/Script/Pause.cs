using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject storeMenu;
    public GameObject pauseMenu;
    private bool paused = false;
    private bool storeOpen = false;
    public AudioSource button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        button.Play();
        if (!paused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
            pauseMenu.SetActive(false);
        }
    }
    public void OpenStore()
    {
        button.Play();
        if (!storeOpen)
        {
            Time.timeScale = 0f;
            storeMenu.SetActive(true);
            storeOpen = true;
        }
        else
        {
            Time.timeScale = 1f;
            storeOpen = false;
            storeMenu.SetActive(false);
        }
    }
    public void exitGame()
    {
        button.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
