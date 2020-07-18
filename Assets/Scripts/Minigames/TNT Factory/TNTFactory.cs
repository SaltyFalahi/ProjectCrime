using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTFactory : MonoBehaviour
{
    public GameObject t;
    public GameObject n;

    public List<Transform> pos;

    public List<TNTPlatform> right;
    public List<TNTPlatform> left;

    public int speed;

    public float timer;

    int countR;
    int countL;

    float countdown;

    void Start()
    {
        countdown = timer;
    }

    void Update()
    {
        CheckWinners();

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Spawn();
            countdown = timer;
        }
    }

    void CheckWinners()
    {
        for (int i = 0; i < right.Count; i++)
        {
            if (right[i].isActive)
            {
                countR++;
            }
            else
            {
                countR = 0;
                break;
            }
        }

        for (int i = 0; i < left.Count; i++)
        {
            if (left[i].isActive)
            {
                countL++;
            }
            else
            {
                countL = 0;
                break;
            }
        }

        if (countR > 3)
        {
            Debug.Log("Right team wins");
        }

        if (countL > 3)
        {
            Debug.Log("Left team wins");
        }
    }

    void Spawn()
    {
        int random = Random.Range(0, 2);
        
        if (random > 0)
        {
            GameObject b = Instantiate(n);
            b.transform.position = pos[Random.Range(0, pos.Count)].position;
        }
        else
        {
            GameObject b = Instantiate(t);
            b.transform.position = pos[Random.Range(0, pos.Count)].position;
        }
    }
}
