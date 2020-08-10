using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafterPlayerController : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    RafterManager rMan;

    Rigidbody rb;

    bool isDead;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;

    int jumpCounter = 1;

    string jump;
    string movementH;
    string movementV;

    // Start is called before the first frame update
    void Start()
    {
        rMan = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<RafterManager>();
        rb = GetComponent<Rigidbody>();
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

            rb.AddForce(movement * moveSpeed);

            if (Input.GetButtonDown(jump) && jumpCounter >= 1)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                jumpCounter--;
            }
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                jump = "P1Fire1";
                movementH = "P1Horizontal";
                movementV = "P1Vertical";
                break;

            case player.P2:
                jump = "P2Fire1";
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                break;

            case player.P3:
                jump = "P3Fire1";
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                break;

            case player.P4:
                jump = "P4Fire1";
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCounter = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isDead = true;
        transform.position = rMan.placesList[rMan.index].transform.position;
        transform.rotation = rMan.placesList[rMan.index].transform.rotation;
        rMan.index++;
    }
}
