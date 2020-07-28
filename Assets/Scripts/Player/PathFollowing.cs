using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public NumberRolled numberRolled;

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
        diceRoller = GetComponent<DiceRoller>();
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    void Update()
    {
        Debug.Log(diceRoller.diceRolled);
        if (diceRoller.diceRolled && !playerAbilities.moneyMagnetIsActive)
        {
            MovePlayer(numberRolled.value);
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
                numberRolled.value--;
                reversePoints.Add(tilePoints[index]);

                if (reversePoints.Count > 6)
                {
                    reversePoints.RemoveAt(0);
                }
            }
        }
    }
}