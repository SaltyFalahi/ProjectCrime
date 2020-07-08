using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D6Result : MonoBehaviour
{
    public enum Numbers
    {
        one,
        two,
        three,
        four,
        five,
        six
    }

    public Numbers side;

    public Text result;

    public D6 d6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (d6.diceVelocity.x == 0 && d6.diceVelocity.y == 0 && d6.diceVelocity.z == 0)
        {
            switch (side)
            {
                case Numbers.one:
                    result.text = "6";
                    break;

                case Numbers.two:
                    result.text = "5";
                    break;

                case Numbers.three:
                    result.text = "4";
                    break;

                case Numbers.four:
                    result.text = "3";
                    break;

                case Numbers.five:
                    result.text = "2";
                    break;

                case Numbers.six:
                    result.text = "1";
                    break;

                default:
                    break;
            }
        }
    }
}
