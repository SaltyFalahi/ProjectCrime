using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> tilePoints;

    public GameObject player;

    public float speed = 2.5f;
    public float reachDist = 1;

    List<Transform> reversePoints = new List<Transform>();

    DiceRoller diceRoller;

    int index = 0;
    int reverseIndex = 0;

    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
    }

    void Update()
    {
        if (diceRoller.diceRolled)
        {
            MovePlayer(diceRoller.numberRolled);
        }
    }

    void MovePlayer(int spacesToMove)
    {
        float dist = Vector3.Distance(tilePoints[index].position, transform.position);

        if (diceRoller.isMoonwalk)
        {
            if (spacesToMove > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, tilePoints[index].position, Time.deltaTime * speed);
            }

            if (dist <= reachDist)
            {
                index++;
                spacesToMove--;
                reversePoints.Add(tilePoints[index]);
            }
        }
        else
        {
            if (spacesToMove < 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, reversePoints[reverseIndex].position, Time.deltaTime * speed);
            }

            if (dist <= reachDist)
            {
                if (reversePoints.Count > 6)
                {
                    reversePoints.RemoveAt(7);
                }

                reverseIndex++;
                index--;
                spacesToMove++;
            }

            if (reverseIndex > reversePoints.Count)
            {
                reversePoints.Clear();
                reverseIndex = 0;
            }
        }
    }
}
