using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour
{
    public TurnController tc;

    public PlayerList pList;

    public PlayerInfo pi1;
    public PlayerInfo pi2;
    public PlayerInfo pi3;
    public PlayerInfo pi4;

    public PathFollowing pf1;
    public PathFollowing pf2;
    public PathFollowing pf3;
    public PathFollowing pf4;

    public PlayerData player1;
    public PlayerData player2;
    public PlayerData player3;
    public PlayerData player4;

    private void Start()
    {
        pList = GameObject.FindGameObjectWithTag("PlayerList").GetComponent<PlayerList>();

        pi1 = pList.players[0].GetComponent<PlayerInfo>();
        pi2 = pList.players[1].GetComponent<PlayerInfo>();
        pf1 = pList.players[0].GetComponent<PathFollowing>();
        pf2 = pList.players[1].GetComponent<PathFollowing>();
    }

    public void SavePlayers()
    {
        player1.bucks = pi1.bucks;
        player1.diamonds = pi1.diamonds;
        player1.sneakers = pi1.sneakers;
        player1.rocketShoes = pi1.rocketShoes;
        player1.moonwalkShoes = pi1.moonwalkShoes;
        player1.getawayVan = pi1.getawayVan;
        player1.shovel = pi1.shovel;
        player1.moneyMags = pi1.moneyMags;
        player1.thiefGloves = pi1.thiefGloves;
        player1.iKnowAGuy = pi1.iKnowAGuy;
        player1.ironBall = pi1.ironBall;
        player1.index = pf1.index;
        player1.position = pf1.gameObject.transform.position;

        for (int i = 0; i < pf1.tilePoints.Count; i++)
        {
            player1.tilePoints.Add(pf1.tilePoints[i].position);
        }

        player2.bucks = pi2.bucks;
        player2.diamonds = pi2.diamonds;
        player2.sneakers = pi2.sneakers;
        player2.rocketShoes = pi2.rocketShoes;
        player2.moonwalkShoes = pi2.moonwalkShoes;
        player2.getawayVan = pi2.getawayVan;
        player2.shovel = pi2.shovel;
        player2.moneyMags = pi2.moneyMags;
        player2.thiefGloves = pi2.thiefGloves;
        player2.iKnowAGuy = pi2.iKnowAGuy;
        player2.ironBall = pi2.ironBall;
        player2.index = pf2.index;
        player2.position = pf2.gameObject.transform.position;

        for (int i = 0; i < pf2.tilePoints.Count; i++)
        {
            player2.tilePoints.Add(pf2.tilePoints[i].position);
        }
    }

    public void LoadPlayers()
    {
        tc.turn = 0;
        pi1.bucks = player1.bucks;
        pi1.diamonds = player1.diamonds;
        pi1.sneakers = player1.sneakers;
        pi1.rocketShoes = player1.rocketShoes;
        pi1.moonwalkShoes = player1.moonwalkShoes;
        pi1.getawayVan = player1.getawayVan;
        pi1.shovel = player1.shovel;
        pi1.moneyMags = player1.moneyMags;
        pi1.thiefGloves = player1.thiefGloves;
        pi1.iKnowAGuy = player1.iKnowAGuy;
        pi1.ironBall = player1.ironBall;
        pf1.index = player1.index;
        pf1.gameObject.transform.position = player1.position;

        for (int i = 0; i < player1.tilePoints.Count; i++)
        {
            GameObject temp = new GameObject();
            temp.transform.position = new Vector3(player1.tilePoints[i].x, player1.tilePoints[i].y, player1.tilePoints[i].z);
            pf1.tilePoints.Add(temp.transform);
        }

        pi2.bucks = player2.bucks;
        pi2.diamonds = player2.diamonds;
        pi2.sneakers = player2.sneakers;
        pi2.rocketShoes = player2.rocketShoes;
        pi2.moonwalkShoes = player2.moonwalkShoes;
        pi2.getawayVan = player2.getawayVan;
        pi2.shovel = player2.shovel;
        pi2.moneyMags = player2.moneyMags;
        pi2.thiefGloves = player2.thiefGloves;
        pi2.iKnowAGuy = player2.iKnowAGuy;
        pi2.ironBall = player2.ironBall;
        pf2.index = player2.index;
        pf2.gameObject.transform.position = player2.position;

        for (int i = 0; i < player2.tilePoints.Count; i++)
        {
            GameObject temp = new GameObject();
            temp.transform.position = new Vector3(player2.tilePoints[i].x, player2.tilePoints[i].y, player2.tilePoints[i].z);
            pf2.tilePoints.Add(temp.transform);
        }
    }
}
