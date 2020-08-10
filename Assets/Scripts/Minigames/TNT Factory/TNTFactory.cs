using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TNTFactory : MonoBehaviour
{
    public Standing standing;

    public GameObject t;
    public GameObject n;

    public List<Transform> pos;

    public List<TNTPlatform> right;
    public List<TNTPlatform> left;

    public List<GameObject> rightTeam;
    public List<GameObject> leftTeam;

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
            for (int i = 0; i < rightTeam.Count; i++)
            {
                if (rightTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P1")
                {
                    standing.p1 = 5;

                }
                if (rightTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P2")
                {
                    standing.p2 = 5;

                }
                if (rightTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P3")
                {
                    standing.p3 = 5;

                }
                if (rightTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P4")
                {
                    standing.p4 = 5;

                }
            }
            SceneManager.LoadScene(1);
        }

        if (countL > 3)
        {
            for (int i = 0; i < leftTeam.Count; i++)
            {
                if (leftTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P1")
                {
                    standing.p1 = 5;

                }
                if (leftTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P2")
                {
                    standing.p2 = 5;

                }
                if (leftTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P3")
                {
                    standing.p3 = 5;

                }
                if (leftTeam[i].GetComponent<TNTFactoryMovement>().type.ToString() == "P4")
                {
                    standing.p4 = 5;

                }
            }
            SceneManager.LoadScene(1);
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
