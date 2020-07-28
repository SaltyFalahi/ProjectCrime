using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D6Result : MonoBehaviour
{
    public D6 d6;

    public int number;

    public bool landed;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Board") || other.CompareTag("ItemSpace"))
        {
            if (d6.diceVelocity.x == 0 && d6.diceVelocity.y == 0 && d6.diceVelocity.z == 0)
            {
                landed = true;
            }
            else
            {
                landed = false;
            }
        }
    }
}
