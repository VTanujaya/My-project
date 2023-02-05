using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    private int point;
    private int expPoint;
    public Text pointText;
    public Slider Slider;
    private int[] levels = new int[] {30,100,1000};
    private int[] minValue = new int[] { 0, 6, 65 };
    private int levelIndex;
    public GameObject[] playerModel;
    private ParticleSystem ParticleSystem;




    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem= GetComponentInChildren<ParticleSystem>();
        levelIndex= 0;
        Slider.maxValue = levels[levelIndex];
        Slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(expPoint >= levels[levelIndex])
        {
            ParticleSystem.Play();
            float positionx = playerModel[levelIndex].transform.position.x;
            playerModel[levelIndex].SetActive(false);
            levelIndex++;
            Slider.minValue= -minValue[levelIndex];
            Slider.maxValue = levels[levelIndex];
            Slider.value = 0;
            expPoint = 0;
            playerModel[levelIndex].SetActive(true);
            playerModel[levelIndex].transform.position = new Vector3 (positionx, playerModel[levelIndex].transform.position.y, playerModel[levelIndex].transform.position.z);
        }
        if (expPoint <0&&levelIndex>0)
        {
            ParticleSystem.Play();
            Debug.Log("a");
            float positionx = playerModel[levelIndex].transform.position.x;
            playerModel[levelIndex].SetActive(false);
            levelIndex--;
            Debug.Log("a");
            expPoint = levels[levelIndex]-5;
            Slider.minValue = -minValue[levelIndex];
            Slider.maxValue = levels[levelIndex];
            Slider.value = levels[levelIndex];
            playerModel[levelIndex].SetActive(true);
            playerModel[levelIndex].transform.position = new Vector3(positionx, playerModel[levelIndex].transform.position.y, playerModel[levelIndex].transform.position.z);

        }
        if (expPoint < 0)
        {
            expPoint = 0;
        }

    }
    public int getPoint()
    {
        return point;
    }
    public void addScore(int pointAdd, int expAdd)
    {
        point += pointAdd;
        expPoint += expAdd;
        Slider.value = expPoint;
        pointText.text = point.ToString();
        Debug.Log(expPoint);
    }
}
