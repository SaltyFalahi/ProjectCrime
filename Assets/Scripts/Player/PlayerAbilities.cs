﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject getawayVan;
    public GameObject diamond;
    public GameObject target;
    public List<int> itemList;

    public bool isMoonwalk = false;
    public bool getawayVanIsActive = false;
    public bool moneyMagnetIsActive = false;
    public bool ironBallIsActive = false;

    int minItems = 1;
    int abilityUsed;

    DiceRoller diceRoller;
    BoardUIManager boardUIManager;
    PlayerInfo myPlayerInfo;


    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
        boardUIManager = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<BoardUIManager>();
        myPlayerInfo = GetComponent<PlayerInfo>();
    }

    void Update()
    {
        if (diceRoller.diceRolled && getawayVanIsActive)
        {
            getawayVan.SetActive(true);
        }
        else
        {
            getawayVan.SetActive(false);
        }
    }

    public void RollSneakers()
    {
        if (myPlayerInfo.sneakers >= minItems)
        {
            diceRoller.diceRolled = true;
            diceRoller.numberRolled = Random.Range(1, 7) + Random.Range(1, 7);
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.sneakers--;
            itemList.Remove(1);

            if (myPlayerInfo.sneakers <= 0)
            {
                myPlayerInfo.sneakers = 0;
            }
            Debug.Log("Sneakers: " + diceRoller.numberRolled);
        }
    }

    public void RollRocket()
    {
        if (myPlayerInfo.rocketShoes >= minItems)
        {
            diceRoller.diceRolled = true;
            diceRoller.numberRolled = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.rocketShoes--;
            itemList.Remove(2);

            if (myPlayerInfo.rocketShoes <= 0)
            {
                myPlayerInfo.rocketShoes = 0;
            }
            Debug.Log("Rocket Shoes: " + diceRoller.numberRolled);
        }
    }

    public void RollMoonwalk()
    {
        if (myPlayerInfo.moonwalkShoes >= minItems)
        {
            isMoonwalk = true;
            diceRoller.RollD6();
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.moonwalkShoes--;
            itemList.Remove(3);

            if (myPlayerInfo.moonwalkShoes <= 0)
            {
                myPlayerInfo.moonwalkShoes = 0;
            }
        }
    }

    public void RollVan()
    {
        if (myPlayerInfo.getawayVan >= minItems)
        {
            getawayVanIsActive = true;
            diceRoller.RollD6();
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.getawayVan--;
            itemList.Remove(4);

            if (myPlayerInfo.getawayVan <= 0)
            {
                myPlayerInfo.getawayVan = 0;
            }
        }
    }

    public void UseShovel()
    {
        if (myPlayerInfo.shovel >= minItems)
        {
            transform.position = new Vector3(diamond.transform.position.x, diamond.transform.position.y + 5, diamond.transform.position.z);
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.shovel--;
            itemList.Remove(5);

            if (myPlayerInfo.shovel <= 0)
            {
                myPlayerInfo.shovel = 0;
            }
        }
    }

    //requires player picking

    public void RollMagnet()
    {
        if (myPlayerInfo.moneyMags >= minItems)
        {
            moneyMagnetIsActive = true;
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.moneyMags--;

            itemList.Remove(6);

            if (myPlayerInfo.moneyMags <= 0)
            {
                myPlayerInfo.moneyMags = 0;
            }

            diceRoller.RollD6();

            diceRoller.diceRolled = false;
            target.GetComponent<PlayerInfo>().bucks -= diceRoller.numberRolled;
            myPlayerInfo.bucks += diceRoller.numberRolled;
        }
    }

    public void UseThiefGloves()
    {
        if (myPlayerInfo.thiefGloves >= minItems && target.GetComponent<PlayerInfo>().itemsLeft >= minItems)
        {
            itemList.Remove(7);

            switch (Random.Range(1, 10))
            {
                case 1:
                    itemList.Remove(1);
                    target.GetComponent<PlayerInfo>().sneakers--;
                    break;

                case 2:
                    itemList.Remove(2);
                    target.GetComponent<PlayerInfo>().rocketShoes--;
                    break;

                case 3:
                    itemList.Remove(3);
                    target.GetComponent<PlayerInfo>().moonwalkShoes--;
                    break;

                case 4:
                    itemList.Remove(4);
                    target.GetComponent<PlayerInfo>().getawayVan--;
                    break;

                case 5:
                    itemList.Remove(5);
                    target.GetComponent<PlayerInfo>().shovel--;
                    break;

                case 6:
                    itemList.Remove(6);
                    target.GetComponent<PlayerInfo>().moneyMags--;
                    break;

                case 7:
                    itemList.Remove(7);
                    target.GetComponent<PlayerInfo>().thiefGloves--;
                    break;

                case 8:
                    itemList.Remove(8);
                    target.GetComponent<PlayerInfo>().iKnowAGuy--;
                    break;

                case 9:
                    itemList.Remove(9);
                    target.GetComponent<PlayerInfo>().ironBall--;
                    break;
            }
        }
    }

    public void UseIKnowAGuy()
    {
        if (myPlayerInfo.iKnowAGuy >= minItems)
        {
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.iKnowAGuy--;

            itemList.Remove(8);

            target.GetComponent<PlayerInfo>().diamonds--;
            myPlayerInfo.diamonds++;

            if (myPlayerInfo.iKnowAGuy <= 0)
            {
                myPlayerInfo.iKnowAGuy = 0;
            }
        }        
    }

    public void RollIronBall() //assumed done
    {
        if (myPlayerInfo.ironBall >= minItems)
        {
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.ironBall--;

            itemList.Remove(9);

            target.GetComponent<PlayerAbilities>().ironBallIsActive = true;

            if (myPlayerInfo.ironBall <= 0)
            {
                myPlayerInfo.ironBall = 0;
            }
        }
    }

    public void SelectPlayer(int index)
    {
        target = myPlayerInfo.playerList[index];

        switch (abilityUsed)
        {
            case 0:
                RollMagnet();
                break;
            case 1:
                RollIronBall();
                break;
            case 2:
                UseThiefGloves();
                break;
            case 3:
                UseIKnowAGuy();
                break;
        }
    }

    public void PlayerSelectPanel(int index)
    {
        abilityUsed = index;
        if (myPlayerInfo.moneyMags >= minItems || myPlayerInfo.thiefGloves >= minItems || 
            myPlayerInfo.ironBall >= minItems || myPlayerInfo.iKnowAGuy >= minItems)
        {
            boardUIManager.OpenPlayerSelectPanel();
        }
    }
}