using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : MonoBehaviour
{
    public int count;

    PlayerInfo player;

    private void OnTriggerEnter(Collider other)
    {
        //If player walks into the space
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            //Gain bucks
            player.bucks += count;
        }
    }
}
