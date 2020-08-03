using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonEscapeManager : MonoBehaviour
{
    public GameObject losePanel;

    public TextMeshProUGUI timerText;

    public float timer;

    PlayerControls pC;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();

        countdown = timer;
    }

    // Update is called once per frame
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

        if (pC.isPopped && !losePanel.activeInHierarchy)
        {
            losePanel.SetActive(true);
        }
    }
}
