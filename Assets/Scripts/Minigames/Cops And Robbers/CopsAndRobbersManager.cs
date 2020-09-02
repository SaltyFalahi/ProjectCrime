using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class CopsAndRobbersManager : MonoBehaviour
{
    public Standing standing;

    public TextMeshProUGUI timerText;

    public float timer;

    List<GameObject> cARMCops = new List<GameObject>();

    CopsAndRobbersMovement cARMCriminal;

    int count;
    float countdown;

    void Start()
    {
        cARMCops.AddRange(GameObject.FindGameObjectsWithTag("Cop"));

        cARMCriminal = GameObject.FindGameObjectWithTag("Player 1").GetComponent<CopsAndRobbersMovement>();

        countdown = timer;
    }

    void Update()
    {
        for (int i = 0; i < cARMCops.Count; i++)
        {
            if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().copsWin)
            {
                for (int j = 0; j < cARMCops.Count; j++)
                {
                    cARMCops[i].GetComponent<CopsAndRobbersMovement>().copsWin = true;
                }
            }
        }

        for (int i = 0; i < cARMCops.Count; i++)
        {
            if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().copsWin)
            {
                if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().type.ToString() == "P1")
                {
                    standing.p1 = 5;
                    count++;
                }
                if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().type.ToString() == "P2")
                {
                    standing.p2 = 5;
                    count++;
                }
                if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().type.ToString() == "P3")
                {
                    standing.p3 = 5;
                    count++;
                }
                if (cARMCops[i].GetComponent<CopsAndRobbersMovement>().type.ToString() == "P4")
                {
                    standing.p4 = 5;
                    count++;
                }
            }
        }

        if (count >= 0)
        {
            //SceneManager.LoadScene(1);
        }

        if (countdown <= 60 && countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;

            if (cARMCriminal.type.ToString() == "P1")
            {
                standing.p1 = 5;
            }
            if (cARMCriminal.type.ToString() == "P2")
            {
                standing.p2 = 5;
            }
            if (cARMCriminal.type.ToString() == "P3")
            {
                standing.p3 = 5;
            }
            if (cARMCriminal.type.ToString() == "P4")
            {
                standing.p4 = 5;
            }

            SceneManager.LoadScene(1);
        }

        timerText.text = countdown.ToString("00" + "s");
    }
}
