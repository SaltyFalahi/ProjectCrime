using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockPlayerController : MonoBehaviour
{
    public bool isBlue;
    public bool isRed;
    public bool hasPressedButton;

    Rigidbody rb;
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player playerType;

    bool atConsole;

    [SerializeField]
    int moveSpeed;

    string switchButton;
    string movementH;
    string movementV;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown(switchButton) && atConsole)
        {
            hasPressedButton = true;
        }
        else if (!atConsole)
        {
            hasPressedButton = false;
        }
    }

    void GetPlayer()
    {
        switch (playerType)
        {
            case player.P1:
                switchButton = "P1Fire1";
                movementH = "P1Horizontal";
                movementV = "P1Vertical";
                break;

            case player.P2:
                switchButton = "P2Fire1";
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                break;

            case player.P3:
                switchButton = "P3Fire1";
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                break;

            case player.P4:
                switchButton = "P4Fire1";
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LConsole") || other.CompareTag("RConsole"))
        {
            atConsole = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LConsole") || other.CompareTag("RConsole"))
        {
            atConsole = false;
            hasPressedButton = false;
        }
    }
}
