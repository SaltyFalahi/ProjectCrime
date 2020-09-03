using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : MonoBehaviour
{
    public int count;

    BoardController bc;

    PlayerInfo pi;

    PathFollowing pf;

    public bool done;

    private void Awake()
    {
        bc = GameObject.FindGameObjectWithTag("BoardController").GetComponent<BoardController>();
    }

    private void OnTriggerStay(Collider other)
    {
        //If player stops on the space
        if (other.CompareTag("Player") && bc.loaded)
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
