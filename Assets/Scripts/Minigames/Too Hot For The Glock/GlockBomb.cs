using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockBomb : MonoBehaviour
{
    public float mySpeed;
    public float speedMod;

    public int directionInt;

    GlockManager gM;

    Vector3 myStartPos;

    [SerializeField]
    float myStartSpeed;
    float myTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<GlockManager>();

        myStartPos = transform.position;

        mySpeed = myStartSpeed;

        directionInt = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        myTimer += Time.deltaTime;

        if (directionInt == 1)
        {
            transform.position += transform.right * mySpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.right * mySpeed * Time.deltaTime;
        }

        if (myTimer >= 5)
        {
            mySpeed += speedMod * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LConsole") || other.CompareTag("RConsole"))
        {
            mySpeed = myStartSpeed;
            myTimer = 0;
            directionInt = Random.Range(1, 3);

            if (other.CompareTag("LConsole"))
            {
                transform.position = myStartPos;
                gM.lChancesLeft--;
            }

            if (other.CompareTag("RConsole"))
            {
                transform.position = myStartPos;
                gM.rChancesLeft--;
            }
        }
    }
}
