using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BalloonEscapeManager : MonoBehaviour
{
    public Standing standings;

    public BoardController bc;

    public TextMeshProUGUI timerText;

    public List<PlayerControls> players;

    public float timer;

    public int playerCount = 4;

    float countdown;

    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("BoardController").GetComponent<BoardController>();

        countdown = timer;
    }

    void Update()
    {
        if (countdown <= 60 && countdown >= 0 && playerCount >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;

            standings.p1 = (int)players[0].score;
            standings.p2 = (int)players[1].score;
            //standings.p3 = (int)players[2].score;
            //standings.p4 = (int)players[3].score;

            SceneManager.LoadScene(1);
        }

        timerText.text = countdown.ToString("00" + "s");
    }
}
