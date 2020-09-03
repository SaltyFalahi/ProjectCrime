using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverResult : MonoBehaviour
{
    public Standing standing;

    public BoardController bc;

    public List<PlayerStanding> players;

    public Light spotLight;

    public Transform pos;

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

        players[0].obj.GetComponent<Animator>().SetBool("isWinner", true);
        players[0].obj.transform.position = pos.position;

        StartCoroutine("Disco");
    }

    IEnumerator Disco()
    {
        while (true)
        {
            spotLight.color = Random.ColorHSV();
            yield return new WaitForSeconds(1);
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        bc.loaded = false;
    }
}