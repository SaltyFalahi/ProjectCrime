using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotEmitter : MonoBehaviour
{
    public Button AddBtn;
    public Button ReduceBtn;

    public TextMeshProUGUI gunshotText;
    public GameObject winText;
    public GameObject loseText;

    float countdown = 5; //will be used for button activation and deactivation

    int shots;

    // Start is called before the first frame update
    void Start()
    {
        shots = Random.Range(5, 10);
        gunshotText.text = shots.ToString("Shots Fired: " + "00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SetShotCount()
    {
        Debug.Log(shots);
        return shots;
    }

    public void Win()
    {
        if (!winText.activeInHierarchy)
        {
            winText.SetActive(true);
        }
    }

    public void Lose()
    {
        if (!loseText.activeInHierarchy)
        {
            loseText.SetActive(true);
        }
    }
}
