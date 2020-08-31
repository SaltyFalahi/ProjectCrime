﻿using System.Collections;
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

    public Standing standing;

    RafterManager rMan;

    Rigidbody rb;

    bool isDead = false;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float jumpForce;
    
    [SerializeField]
    float rotSpeed;

    int jumpCounter = 1;

    string jump;
    string movementH;
    string movementV;
    string rotateH;

    void Start()
    {
        rMan = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<RafterManager>();
        rb = GetComponent<Rigidbody>();
        GetPlayer();
    }

    void Update()
    {
        if (!isDead)
        {
            Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

            rb.AddForce(transform.forward * Input.GetAxis(movementV) * moveSpeed);
            rb.AddForce(transform.right * Input.GetAxis(movementH) * moveSpeed);

            transform.Rotate(0, Input.GetAxis(rotateH) * rotSpeed * Time.deltaTime, 0);

            Vector3 v = rb.velocity;
            v.x = Mathf.Clamp(v.x, 0, maxSpeed);
            v.z = Mathf.Clamp(v.z, 0, maxSpeed);

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
                rotateH = "P1RotateHorizontal";
                break;

            case player.P2:
                jump = "P2Fire1";
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                rotateH = "P2RotateHorizontal";
                break;

            case player.P3:
                jump = "P3Fire1";
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                rotateH = "P3RotateHorizontal";
                break;

            case player.P4:
                jump = "P4Fire1";
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                rotateH = "P4RotateHorizontal";
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCounter = 1;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            jumpForce = 0;
            moveSpeed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isDead = true;
            transform.position = rMan.placesList[rMan.index].transform.position;
            transform.rotation = rMan.placesList[rMan.index].transform.rotation;
            rMan.index++;
        }

        if (other.CompareTag("Cop"))
        {
            isDead = true;
            transform.position = rMan.placesList[rMan.rIndex].transform.position;
            transform.rotation = rMan.placesList[rMan.rIndex].transform.rotation;
            rMan.rIndex--;
        }
    }
}
