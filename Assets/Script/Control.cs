using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public Text pointText;
    public Slider Slider;
    private int point;
    private int expPoint;
    // Start is called before the first frame update
    void Start()
    {
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
                        UnityEngine.Debug.Log("screen");
                        if (hit.collider.name == "Boat")
                        {
                            rb.transform.position = cam.ScreenToWorldPoint(new Vector3(touch.position.x, originalSpot.y, originalSpot.z));
                            UnityEngine.Debug.Log("move");
                        }
                    }

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
        if (collision.gameObject.CompareTag("Coin"))
        {
            point += 5;
            expPoint+= 5;
            pointText.text = point.ToString();
            Destroy(collision.gameObject);
            Slider.value = expPoint;
        }
        
    }
}
