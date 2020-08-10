using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    List<GameObject> playerWorldList;

    public int bucks;
    public int diamonds;

    public int itemsLeft = 0;

    public int sneakers;
    public int rocketShoes;
    public int moonwalkShoes;
    public int getawayVan;
    public int shovel;
    public int moneyMags;
    public int thiefGloves;
    public int iKnowAGuy;
    public int ironBall;

    int maxItems = 5;

    void Start()
    {
        playerWorldList = GameObject.FindGameObjectWithTag("PlayerList").GetComponent<PlayerList>().players;

        for (int i = 0; i < playerWorldList.Count; i++)
        {
            if (playerWorldList[i] != gameObject)
            {
                playerList.Add(playerWorldList[i]);
            }
        }
    }

    void Update()
    {
        if (itemsLeft >= maxItems)
        {
            itemsLeft = maxItems;
        }
        else
        {
            itemsLeft = sneakers + rocketShoes + shovel + thiefGloves + moneyMags + moonwalkShoes + iKnowAGuy + getawayVan + ironBall;
        }

        if(bucks <= 0)
        {
            bucks = 0;
        }
    }
}
