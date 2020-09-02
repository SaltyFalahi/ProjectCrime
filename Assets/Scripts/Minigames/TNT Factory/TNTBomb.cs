using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBomb : MonoBehaviour
{
    public float timer;

    TNTFactoryMovement player;

    float countdown;

    bool start;

    void Start()
    {
        countdown = timer;
    }

    void Update()
    {
        if (start)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                player.bombed = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<TNTFactoryMovement>();
            player.bombed = true;
            start = true;
        }
    }
}
