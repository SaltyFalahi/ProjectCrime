using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public List<GameObject> blocks;

    public Transform guide;
    
    public int moveSpeed;

    Rigidbody rb;

    string movementH;
    string movementV;
    string fire;

    bool isCarrying;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        blocks = new List<GameObject>();
        GetPlayer();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), 0, Input.GetAxis(movementV));

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown(fire) && blocks.Count > 0 && !isCarrying)
        {
            GetClosestBlock(blocks).transform.parent = transform;
            GetClosestBlock(blocks).GetComponent<Rigidbody>().useGravity = false;
            isCarrying = true;
        }
        else if (Input.GetButtonDown(fire) && isCarrying)
        {
            transform.GetChild(1).GetComponent<Rigidbody>().useGravity = false;
            transform.GetChild(1).parent = null;
            isCarrying = false;
            blocks.Clear();
        }

        if (isCarrying)
        {
            transform.GetChild(1).position = guide.position;
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                movementH = "P1Horizontal";
                movementV = "P1Vertical";
                fire = "P1Fire1";
                break;

            case player.P2:
                movementH = "P2Horizontal";
                movementV = "P2Vertical";
                fire = "P2Fire1";
                break;

            case player.P3:
                movementH = "P3Horizontal";
                movementV = "P3Vertical";
                fire = "P3Fire1";
                break;

            case player.P4:
                movementH = "P4Horizontal";
                movementV = "P4Vertical";
                fire = "P4Fire1";
                break;
        }
    }

    GameObject GetClosestBlock(List<GameObject> gameObjects)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in gameObjects)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);

            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("T") || other.CompareTag("N"))
        {
            blocks.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("T") || other.CompareTag("N"))
        {
            blocks.Remove(other.gameObject);
        }
    }
}
