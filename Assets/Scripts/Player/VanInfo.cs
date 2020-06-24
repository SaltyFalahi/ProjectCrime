using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanInfo : MonoBehaviour
{
    DiceRoller diceRoller;
    PlayerInfo otherPlayerInfo;
    PlayerInfo myPlayerInfo;

    public int moneyToSteal;

    // Start is called before the first frame update
    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
        myPlayerInfo = GetComponentInParent<PlayerInfo>();
        moneyToSteal = diceRoller.numberRolled;

        Debug.Log("Money: " + moneyToSteal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider vanTrig)
    {
        if (vanTrig.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Stealing money");

            otherPlayerInfo = vanTrig.gameObject.GetComponent<PlayerInfo>();
            otherPlayerInfo.bucks -= moneyToSteal;
            myPlayerInfo.bucks += moneyToSteal;
        }
    }
}
