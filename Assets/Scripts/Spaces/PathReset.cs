using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathReset : MonoBehaviour
{
    public List<Transform> mainPath;

    PathFollowing pf;

    public bool done;

    private void OnTriggerStay(Collider other)
    {
        //If player stops on the space
        if (other.CompareTag("Player"))
        {
            pf = other.GetComponent<PathFollowing>();

            pf.tilePoints.Clear();
            pf.tilePoints.AddRange(mainPath);
        }
    }
}
