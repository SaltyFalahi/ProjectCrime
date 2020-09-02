using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFollowing : MonoBehaviour
{
    public NumberRolled numberRolled;

    public BoardUIManager bm;

    public List<Transform> tilePoints;
    public List<Transform> rightPoints;
    public List<Transform> leftPoints;

    public GameObject player;

    public float speed;
    public float reachDist;
    
    public int index = 0;
    public int path;

    public bool isMoving;
    public bool directionSpace;

    Animator myAnim;
    DiceRoller diceRoller;
    PlayerAbilities playerAbilities;
    TurnController turnController;

    void Start()
    {
        diceRoller = GetComponent<DiceRoller>();
        myAnim = GetComponentInChildren<Animator>();
        playerAbilities = GetComponent<PlayerAbilities>();
        turnController = GameObject.FindGameObjectWithTag("PlayerList").GetComponent<TurnController>();
    }

    void Update()
    {
        if (tilePoints.Count <= index)
        {
            tilePoints.Clear();
        }

        if (diceRoller.diceRolled && !playerAbilities.moneyMagnetIsActive)
        {
            MovePlayer(numberRolled.value);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void MovePlayer(int spacesToMove)
    {
        float dist = Vector3.Distance(tilePoints[index].position, transform.position);

        Vector3 dir = tilePoints[index].position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);

        if (!directionSpace)
        {
            if (spacesToMove > 0)
            {
                myAnim.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, tilePoints[index].position, Time.deltaTime * speed);
            }
            else
            {
                myAnim.SetBool("isRunning", false);
                diceRoller.diceRolled = false;
                playerAbilities.getawayVanIsActive = false;
                turnController.turnOver = true;
            }

            if (dist <= reachDist)
            {
                index++;
                numberRolled.value--;
            }
        }
        else
        {
            bm.OpenDirectionPanel();
        }
    }

    public void NewPoints(int index)
    {
        if (index <= 1)
        {
            tilePoints.AddRange(rightPoints);
        }
        else
        {
            tilePoints.AddRange(leftPoints);
        }

        directionSpace = false;
    }
}