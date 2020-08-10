using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public Standing standing;

    public BoardData bd;

    public List<Scene> minigames;

    public int turn = 1;

    public bool turnOver;

    PlayerList list;

    int coins = 9;
    void Start()
    {
        list = GetComponent<PlayerList>();
    }

    void Update()
    {
        switch (turn)
        {
            case 0:
                for (int i = 0; i < standing.standings.Count; i++)
                {
                    for (int j = 0; j < list.players.Count; j++)
                    {
                        if (list.players[i].name == standing.standings[j].name)
                        {
                            list.players[i].GetComponent<PlayerInfo>().bucks += coins;
                            Debug.Log("Here");
                            coins -= 2;
                        }
                    }
                }
                coins = 9;
                turn = 1;
                break;

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
                    turn = 5;
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
                bd.SavePlayers();
                SceneManager.LoadScene(minigames[Random.Range(0, minigames.Count)].handle);
                break;
        }
    }
}

