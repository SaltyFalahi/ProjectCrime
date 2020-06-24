using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int bucks;
    public int diamonds;

    public int itemsLeft = 0;
    public int minItems = 1;

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
    }
}
