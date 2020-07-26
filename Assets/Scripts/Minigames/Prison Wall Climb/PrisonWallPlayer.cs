using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonWallPlayer : MonoBehaviour
{
    public float rappelSpeed;

    public int moveSpeed;

    PrisonWallEscapeManager pWEP;

    Rigidbody rb;

    string movementH = "P1Horizontal";

    // Start is called before the first frame update
    void Start()
    {
        pWEP = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<PrisonWallEscapeManager>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis(movementH), -rappelSpeed, 0);

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            moveSpeed = 0;

            pWEP.playersLeft--;

            if (!pWEP.losePanel.activeInHierarchy)
            {
                pWEP.losePanel.SetActive(true);
            }
        }

        if (other.gameObject.tag.Equals("Finish"))
        {
            moveSpeed = 0;

            pWEP.PlayerWin();
        }
    }
}
