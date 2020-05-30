using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> tilePoints = new List<Transform>();

    public GameObject player;

    DiceRoller diceRoller;

    public float speed = 2.5f;
    public float reachDist = 1;

    int index = 0;
    int spacesToMove;
    int currentTileNum;

    // Start is called before the first frame update
    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("DiceObj").GetComponent<DiceRoller>();
        spacesToMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (diceRoller.diceRolled)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        
    }
}
