using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject getawayVan;
    public GameObject diamond;

    public bool isMoonwalk = false;
    public bool getawayVanIsActive = false;
    public bool moneyMagnetIsActive = false;

    DiceRoller diceRoller;
    PlayerInfo myPlayerInfo;

    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
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
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.sneakers >= myPlayerInfo.minItems)
        {
            diceRoller.diceRolled = true;
            diceRoller.numberRolled = Random.Range(1, 7) + Random.Range(1, 7);
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.sneakers--;
            Debug.Log("Sneakers: " + diceRoller.numberRolled);
        }
    }

    public void RollRocket()
    {
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.rocketShoes >= myPlayerInfo.minItems)
        {
            diceRoller.diceRolled = true;
            diceRoller.numberRolled = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.rocketShoes--;
            Debug.Log("Rocket Shoes: " + diceRoller.numberRolled);
        }
    }

    public void RollMoonwalk()
    {
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.moonwalkShoes >= myPlayerInfo.minItems)
        {
            isMoonwalk = true;
            diceRoller.RollD6();
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.moonwalkShoes--;
        }
    }

    public void RollVan()
    {
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.getawayVan >= myPlayerInfo.minItems)
        {
            getawayVanIsActive = true;
            diceRoller.RollD6();
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.getawayVan--;
        }
    }

    public void UseShovel()
    {
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.getawayVan >= myPlayerInfo.minItems)
        {
            transform.position = new Vector3(diamond.transform.position.x, diamond.transform.position.y + 5, diamond.transform.position.z);
        }
    }

    public void RollMagnet()
    {
        if (myPlayerInfo.itemsLeft >= myPlayerInfo.minItems && myPlayerInfo.moneyMags >= myPlayerInfo.minItems)
        {
            moneyMagnetIsActive = true;
            myPlayerInfo.itemsLeft--;
            myPlayerInfo.moneyMags--;
        }
    }
}