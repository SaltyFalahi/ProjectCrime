using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int numberRolled;

    public bool diceRolled = false;
    public bool isNormalRoll = false;
    public bool isMoonwalk = false;
    public bool isVan = false;

    public void RollD4()
    {
        diceRolled = true;
        numberRolled = Random.Range(1, 5);
        Debug.Log("D4: " + numberRolled);
    }

    public void RollD6()
    {
        diceRolled = true;
        
        if (isMoonwalk)
        {
            numberRolled = Random.Range(1, 7) * -1;
            Debug.Log("Moonwalk " + numberRolled);
        }
        else
        {
            numberRolled = Random.Range(1, 7);
            Debug.Log("D6: " + numberRolled);
        }
    }

    public void RollNormalMovement()
    {
        isNormalRoll = true;
        RollD6();
    }

    public void RollSneakers()
    {
        diceRolled = true;
        numberRolled = Random.Range(1, 7) + Random.Range(1, 7);
        Debug.Log("Sneakers: " + numberRolled);
    }

    public void RollRocket()
    {
        diceRolled = true;
        numberRolled = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
        Debug.Log("Rocket Shoes: " + numberRolled);
    }

    public void RollMoonwalk()
    {
        isMoonwalk = true;
        RollD6();
    }

    public void RollVan()
    {
        isVan = true;
        RollD6();
    }
}