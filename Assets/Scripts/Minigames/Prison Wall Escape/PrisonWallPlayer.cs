using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonWallPlayer : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    Animator myAnim;
    PrisonWallEscapeManager pWEP;
    Rigidbody rb;

    [SerializeField]
    float vRappelSpeed;
    [SerializeField]
    float hRappelSpeed;
    [SerializeField]
    float acceleration;

    [SerializeField]
    int moveSpeed;

    string movementH;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        pWEP = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<PrisonWallEscapeManager>();
        rb = GetComponent<Rigidbody>();

        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH) * hRappelSpeed, -vRappelSpeed, 0);

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (pWEP.distanceToGround <= pWEP.speedPoint)
        {
            vRappelSpeed += acceleration * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cop"))
        {
            moveSpeed = 0;

            pWEP.playersLeft--;

            if (!pWEP.losePanel.activeInHierarchy)
            {
                pWEP.losePanel.SetActive(true);
            }
        }

        if (other.CompareTag("Finish"))
        {
            moveSpeed = 0;

            pWEP.PlayerWin();
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                movementH = "P1Horizontal";
                break;

            case player.P2:
                movementH = "P2Horizontal";
                break;

            case player.P3:
                movementH = "P3Horizontal";
                break;

            case player.P4:
                movementH = "P4Horizontal";
                break;
        }
    }
}
