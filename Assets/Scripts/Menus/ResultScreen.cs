using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public Standing standing;

    public BoardController bc;

    public Text text;

    public List<PlayerStanding> players;

    public List<Transform> positions;

    public GameObject po1;
    public GameObject po2;
    public GameObject po3;
    public GameObject po4;

    PlayerStanding p1 = new PlayerStanding();
    PlayerStanding p2 = new PlayerStanding();
    PlayerStanding p3 = new PlayerStanding();
    PlayerStanding p4 = new PlayerStanding();

    void Awake()
    {
        bc = GameObject.FindGameObjectWithTag("BoardController").GetComponent<BoardController>();
        players = new List<PlayerStanding>();

        p1.score = standing.p1;
        p2.score = standing.p2;
        //p3.score = standing.p3;
        //p4.score = standing.p4;

        p1.name = "Player 1";
        p2.name = "Player 2";
        //p3.name = "Player 3";
        //p4.name = "Player 4";

        p1.obj = po1;
        p2.obj = po2;
        //p3.obj = po3;
        //p4.obj = po4;

        players.Add(p1);
        players.Add(p2);
        //players.Add(p3);
        //players.Add(p4);

        players.Sort(delegate (PlayerStanding p1, PlayerStanding p2) { return p1.score.CompareTo(p2.score); });
        players.Reverse();

        for (int i = 0; i < positions.Count; i++)
        {
            if (i == 0)
            {
                players[i].obj.GetComponent<ResutlsAnimation>().isWinner = true;
            }
            players[i].obj.transform.position = positions[i].position;
        }

        p1.obj = null;
        p2.obj = null;
        //p3.obj = null;
        //p4.obj = null;

        standing.standings = players;
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(2);
        bc.loaded = false;
    }
}

[System.Serializable]
public class PlayerStanding
{
    public GameObject obj;
    public float score;
    public string name;
}