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

    public HotPotatoManager instance;

    public int moveSpeed;

    Animator myAnim;
    Rigidbody rb;

    [SerializeField]
    bool canReceiveBomb;
    [SerializeField]
    bool hasGivenBomb;
    [SerializeField]
    bool hasBomb;

    string movementH;
    string movementV;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        GetPlayer();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            myAnim.SetBool("isRunning", true);
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }

        if (instance.player == gameObject)
        {
            canReceiveBomb = false;
            hasGivenBomb = false;
            hasBomb = true;
        }
        else
        {
            hasGivenBomb = true;
            hasBomb = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (instance.player == gameObject && collision.gameObject.CompareTag("Player") && hasBomb)
        {
            Debug.Log("hi");

            instance.PassBomb(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !canReceiveBomb && hasGivenBomb)
        {
            Debug.Log("oh no");

            canReceiveBomb = true;
        }
    }
}
