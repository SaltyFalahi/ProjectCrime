﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlayerController : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public int score;

    Animator myAnim;
    Rigidbody rb;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;

    int jumpCounter = 1;

    string jump;
    string movementH;
    string movementV;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GetPlayer();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (movement != Vector3.zero && !myAnim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            myAnim.SetBool("isRunning", true);
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown(jump) && jumpCounter >= 1)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            myAnim.SetBool("isJumping", true);

            jumpCounter--;
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
            myAnim.SetBool("isJumping", false);
            jumpCounter = 1;
        }
    }
}
