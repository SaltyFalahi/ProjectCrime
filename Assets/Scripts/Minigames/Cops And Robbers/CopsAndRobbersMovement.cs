using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsAndRobbersMovement : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public bool cops;
    public bool copsWin = false;

    public int moveSpeed;

    Rigidbody rb;

    string movementH;
    string movementV;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetPlayer();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

        if (!cops)
        {
            rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(transform.position + movement * moveSpeed * Time.deltaTime);
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                movementH = "P1Horizontal";
                movementV = "P1Vertical";
                break;

            case player.P2:
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                break;

            case player.P3:
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                break;

            case player.P4:
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player 1"))
        {
            moveSpeed = 0;

            copsWin = true;

            Destroy(other.gameObject);

            Debug.Log("Blue Won");
        }
    }
}
