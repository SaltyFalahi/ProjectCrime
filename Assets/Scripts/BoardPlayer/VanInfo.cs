using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanInfo : MonoBehaviour
{
    public NumberRolled numberRolled;

    PlayerInfo otherPlayerInfo;
    PlayerInfo myPlayerInfo;

    public int moneyToSteal;

    void Start()
    {
        myPlayerInfo = GetComponentInParent<PlayerInfo>();
        moneyToSteal = numberRolled.value;
        Debug.Log("Money: " + moneyToSteal);
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
