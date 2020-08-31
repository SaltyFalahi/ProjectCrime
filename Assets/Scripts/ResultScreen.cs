using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public Standing standing;

    public BoardController bc;

    public List<PlayerStanding> players;

    public Text text;

    PlayerStanding p1 = new PlayerStanding();
    PlayerStanding p2 = new PlayerStanding();
    PlayerStanding p3 = new PlayerStanding();
    PlayerStanding p4 = new PlayerStanding();

    void Start()
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

        players.Add(p1);
        players.Add(p2);
        //players.Add(p3);
        //players.Add(p4);

        players.Sort(delegate (PlayerStanding p1, PlayerStanding p2) { return p1.score.CompareTo(p2.score); });
        players.Reverse();

        standing.standings = players;
    }

    void Update()
    {
        text.text = ("Rankings:" + "\n" + "\n" + players[0].name + "\n" + "\n" + players[1].name);
    }

    public void Button()
    {
        SceneManager.LoadScene(0);
        bc.loaded = false;
    }
}

[System.Serializable]
public class PlayerStanding
{
    public int score;
    public string name;
}