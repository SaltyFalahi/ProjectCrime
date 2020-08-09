using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CopsAndRobbersManager : MonoBehaviour
{
    public GameObject copsPanel;
    public GameObject robberPanel;

    public TextMeshProUGUI timerText;

    public float timer;

    CopsAndRobbersMovement cARMCops;
    CopsAndRobbersMovement cARMCriminal;

    float countdown;

    void Start()
    {
        cARMCops = GameObject.FindGameObjectWithTag("Cop").GetComponent<CopsAndRobbersMovement>();

        cARMCriminal = GameObject.FindGameObjectWithTag("Player 1").GetComponent<CopsAndRobbersMovement>();

        countdown = timer;
    }

    void Update()
    {
        if (countdown <= 60 && countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;
        }

        timerText.text = countdown.ToString("00" + "s");

        if (!copsPanel.activeInHierarchy && cARMCops.copsWin)
        {
            copsPanel.SetActive(true);
        }

        if (!robberPanel.activeInHierarchy && countdown <= 0)
        {
            cARMCriminal.moveSpeed = 0;

            robberPanel.SetActive(true);

            Debug.Log("Red won");
        }
    }
}
