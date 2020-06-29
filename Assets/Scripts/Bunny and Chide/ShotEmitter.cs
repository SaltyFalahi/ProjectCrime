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

    IEnumerator coroutine;

    float countdown = 5; //will be used for button activation and deactivation
    float shotTimer;

    int shotsToFire;
    int shotsFired;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = Random.Range(1, 6);
        shotsToFire = Random.Range(5, 11);
        gunshotText.text = shotsToFire.ToString("Shots Fired: " + "00");

        coroutine = StartShots(shotTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartShots(float time)
    {
        yield return new WaitForSeconds(time);

        //if ()
        //{
            
        //}
    }

    public int SetShotCount()
    {
        Debug.Log(shotsToFire);
        return shotsToFire;
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
