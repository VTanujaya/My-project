using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Control : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    private Vector3 originalSpot;
    private float limitX = 16;
    private bool gameStart = true;
    private bool invul;
    private points points;
    private PowerUp powerUp;
    private int time;
    public AudioSource coin;
    public AudioSource rock;
    public AudioSource chest;
    public AudioSource turbo;
    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("Player").GetComponent<points>();
        powerUp= GameObject.Find("PowerUps").GetComponent<PowerUp>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        originalSpot = cam.WorldToScreenPoint(rb.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {

                    RaycastHit hit = new RaycastHit();
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out hit))
                    {

                        if (hit.collider.tag != "Player") continue;
                        if (Time.timeScale == 0) continue;
                        rb.transform.position = cam.ScreenToWorldPoint(new Vector3(touch.position.x, originalSpot.y, originalSpot.z));
                        
                    }
                }
                if (touch.tapCount > 1 && (powerUp.turbo1||powerUp.turbo2)&&!invul)
                {
                    turbo.Play();
                    invul = true;
                    UnityEngine.Debug.Log("start");
                    StartCoroutine("powerUpCount");
                }
            }
            if (transform.position.x < -limitX)
            {
                transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
            }
            if (transform.position.x > limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        int score;
        switch (gameObject.name)
        {
            case "slab":
                score = 5;
                break;
            case "boat":
                score = 10;
                break;
            case "warship":
                score = 15;
                break;
            default:
                score = 5;
                break;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            points.addScore(score, score);
            Destroy(collision.gameObject);
            coin.Play();
        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            points.addScore(score*2, score*2);
            Destroy(collision.gameObject);
            chest.Play();
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            rock.Play();
            if (invul)
            {
                points.addScore(score - 5, score - 5);
                Destroy(collision.gameObject);
            }
            else
            {
                points.addScore(0, -score);
                Destroy(collision.gameObject);
            }
        }
    }
    IEnumerator powerUpCount()
    {
        UnityEngine.Debug.Log("Test");
        yield return new WaitForSeconds(10);
        invul = false;
        turbo.Stop();
        UnityEngine.Debug.Log("timeup");
        if (powerUp.turbo1)
        {
            powerUp.turbo1 = false;
            powerUp.buy[0].enabled= true;
        }
        else if (powerUp.turbo2)
        {
            powerUp.turbo2 = false;
            powerUp.buy[1].enabled = true;
        }
    }
}
