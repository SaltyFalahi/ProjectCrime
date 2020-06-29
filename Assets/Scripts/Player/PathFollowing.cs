using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> tilePoints;

    public GameObject player;

    public float speed;
    public float reachDist;

    public List<Transform> reversePoints = new List<Transform>();

    DiceRoller diceRoller;
    PlayerAbilities playerAbilities;

    int index = 0;
    int reverseIndex = 0;

    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    void Update()
    {
        if (diceRoller.diceRolled && !playerAbilities.moneyMagnetIsActive)
        {
            MovePlayer(diceRoller.numberRolled);
        }
    }

    void MovePlayer(int spacesToMove)
    {
        float dist = Vector3.Distance(tilePoints[index].position, transform.position);

        if (!playerAbilities.isMoonwalk)
        {
            if (spacesToMove > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, tilePoints[index].position, Time.deltaTime * speed);
            }
            else
            {
                diceRoller.diceRolled = false;
                playerAbilities.getawayVanIsActive = false;
            }

            if (dist <= reachDist)
            {
                index++;
                diceRoller.numberRolled--;
                reversePoints.Add(tilePoints[index]);

                if (reversePoints.Count > 6)
                {
                    reversePoints.RemoveAt(0);
                }
            }
        }
        else
        {
            if (spacesToMove < 0)
            {
                Debug.Log("Moonwalking "+ spacesToMove);
                reverseIndex = (spacesToMove * -1) - 1;
                Debug.Log("REEEEE " + reverseIndex);
                transform.position = Vector3.MoveTowards(transform.position, reversePoints[reverseIndex].position, Time.deltaTime * speed);
            }
            else if (spacesToMove >= 0)
            {
                Debug.Log("No longer Moonwalking");
                playerAbilities.isMoonwalk = false;
                diceRoller.diceRolled = false;
            }

            if (dist <= reachDist)
            {
                if (reversePoints.Count > 6)
                {
                    reversePoints.RemoveAt(0);
                }

                reverseIndex--;
                index--;
                Debug.Log(index);
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