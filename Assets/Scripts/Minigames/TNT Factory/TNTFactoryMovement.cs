using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTFactoryMovement : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public int moveSpeed;

    public bool bombed;

    Animator myAnim;
    Rigidbody rb;
    TNT block;

    string movementH;
    string movementV;
    string drop;

    bool carrying;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GetPlayer();
    }

    void Update()
    {
        if (bombed)
        {
            Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

            rb.AddForce(movement * moveSpeed);

            if (movement != Vector3.zero)
            {
                myAnim.SetBool("isRunning", true);
            }
            else
            {
                myAnim.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown(drop))
            {
                block.parent = null;
                block.GetComponent<Rigidbody>().useGravity = true;
                block.isBeingCarried = false;
                carrying = false;
            }
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                movementH = "P1Horizontal";
                movementV = "P1Vertical";
                drop = "P1Fire1";
                break;

            case player.P2:
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                drop = "P2Fire1";
                break;

            case player.P3:
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                drop = "P3Fire1";
                break;

            case player.P4:
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                drop = "P4Fire1";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("T") && !carrying || other.CompareTag("N") && !carrying)
        {
            block = other.gameObject.GetComponent<TNT>();

            if (!block.isBeingCarried)
            {
                block.parent = gameObject.transform;
                block.GetComponent<Rigidbody>().useGravity = false;
                block.isBeingCarried = true;
                carrying = true;
            }
        }
    }
}
