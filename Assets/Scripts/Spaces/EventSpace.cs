using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpace : MonoBehaviour
{
    public int count;

    PlayerInfo player;

    GameEvent gEvent;

    private void Start()
    {
        //Stores which event is used for this space
        gEvent = GetComponent<GameEvent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player walks into the space
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            
            //Play Event
            gEvent.DoEvent(player);
        }
    }
}
