using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : MonoBehaviour
{
    public int count;

    PlayerInfo pi;
    PathFollowing pf;

    public bool done;

    private void OnTriggerStay(Collider other)
    {
        //If player stops on the space
        if (other.CompareTag("Player"))
        {
            pf = other.GetComponent<PathFollowing>();

            if (!pf.isMoving && !done)
            {
                pi = other.GetComponent<PlayerInfo>();
                //Gain bucks
                pi.bucks += count;

                done = true;
            }
        }
    }
}
