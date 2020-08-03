using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public List<Scene> minigames;

    public int turn = 1;

    public bool turnOver;

    PlayerList list;
    void Start()
    {
        list = GetComponent<PlayerList>();
    }

    void Update()
    {
        switch (turn)
        {
            case 1:
                list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(true);

                if (turnOver)
                {
                    list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(false);
                    turn = 2;
                    turnOver = false;
                }
                break;

            case 2:
                list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(true);

                if (turnOver)
                {
                    list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(false);
                    turn = 1;
                    turnOver = false;
                }
                break;

            case 3:
                list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(true);

                if (turnOver)
                {
                    list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(false);
                    turn = 4;
                    turnOver = false;
                }
                break;

            case 4:
                list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(true);

                if (turnOver)
                {
                    list.players[turn - 1].GetComponent<PlayerAbilities>().canvas.SetActive(false);
                    turn = 5;
                    turnOver = false;
                }
                break;

            case 5:
                //Play Minigame
                SceneManager.LoadScene();

                break;
        }
    }
}

