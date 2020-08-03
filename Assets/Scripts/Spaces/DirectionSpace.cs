using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionSpace : MonoBehaviour
{
    public List<Transform> right;
    public List<Transform> left;

    PathFollowing pf;

    bool done;

    private void OnTriggerEnter(Collider other)
    {
        //If player stops on the space
        if (other.CompareTag("Player"))
        {
            pf = other.GetComponent<PathFollowing>();
            pf.rightPoints = right;
            pf.leftPoints = left;
            pf.directionSpace = true;
            done = true;
        }
    }
}
