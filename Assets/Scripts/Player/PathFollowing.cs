using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> tilePoints;

    public GameObject player;

    public float speed;
    public float reachDist;

    List<Transform> reversePoints = new List<Transform>();

    DiceRoller diceRoller;

    int index = 0;
    int reverseIndex = 0;
    int numberToMove;

    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
    }

    void Update()
    {
        if (diceRoller.diceRolled)
        {
            numberToMove = diceRoller.numberRolled;
            MovePlayer(numberToMove);
        }
    }

    void MovePlayer(int spacesToMove)
    {
        float dist = Vector3.Distance(tilePoints[index].position, transform.position);

        if (!diceRoller.isMoonwalk)
        {
            if (spacesToMove > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, tilePoints[index].position, Time.deltaTime * speed);
            }
            else
            {
                diceRoller.diceRolled = false;
            }

            if (dist <= reachDist)
            {
                index++;
                diceRoller.numberRolled--;
                reversePoints.Add(tilePoints[index]);
            }
        }
        else
        {
            if (spacesToMove < 0)
            {
                Debug.Log("Moonwalking");
                transform.position = Vector3.MoveTowards(transform.position, reversePoints[reverseIndex].position, Time.deltaTime * speed);
            }
            else if (spacesToMove >= 0)
            {
                Debug.Log("No longer Moonwalking");
                diceRoller.isMoonwalk = false;
                diceRoller.diceRolled = false;
            }

            if (dist <= reachDist)
            {
                if (reversePoints.Count > 6)
                {
                    reversePoints.RemoveAt(7);
                }

                reverseIndex++;
                index--;
                diceRoller.numberRolled++;
            }

            if (reverseIndex > reversePoints.Count)
            {
                reversePoints.Clear();
                reverseIndex = 0;
            }
        }
    }
}