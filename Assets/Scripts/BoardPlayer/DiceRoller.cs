using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int numberRolled;

    public bool diceRolled = false;

    PlayerAbilities playerAbilities;

    void Start()
    {
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    void RollD4()
    {
        diceRolled = true;
        numberRolled = Random.Range(1, 5);
        Debug.Log("D4: " + numberRolled);
        playerAbilities.target.GetComponent<PlayerAbilities>().ironBallIsActive = false;

    }

    public void RollD6()
    {
        diceRolled = true;
        
        if (playerAbilities.isMoonwalk)
        {
            numberRolled = Random.Range(1, 7) * -1;
            Debug.Log("Moonwalk " + numberRolled);
        }
        else if (playerAbilities.ironBallIsActive)
        {
            RollD4();
        }
        else
        {
            numberRolled = Random.Range(1, 7);
            Debug.Log("D6: " + numberRolled);
        }
    }
}