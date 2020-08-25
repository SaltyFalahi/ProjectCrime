using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotatoMovement : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public HotPotato instance;

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

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
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
        if (other.CompareTag("Player"))
        {
            instance.PassBomb(other.gameObject);
            Debug.Log("hi");
        }
    }
}
