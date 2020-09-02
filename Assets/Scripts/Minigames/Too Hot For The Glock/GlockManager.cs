using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlockManager : MonoBehaviour
{
    public Standing standing;

    public List<GameObject> rightTeam;
    public List<GameObject> leftTeam;

    public int lChancesLeft = 3;
    public int rChancesLeft = 3;

    [SerializeField]
    float timer;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinners();

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            countdown = timer;
        }
    }

    void CheckWinners()
    {
        if (lChancesLeft <= 0)
        {
            for (int i = 0; i < rightTeam.Count; i++)
            {
                if (rightTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P1")
                {
                    standing.p1 = 5;

                }
                if (rightTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P2")
                {
                    standing.p2 = 5;

                }
                if (rightTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P3")
                {
                    standing.p3 = 5;

                }
                if (rightTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P4")
                {
                    standing.p4 = 5;

                }
            }
            SceneManager.LoadScene(1);
        }

        if (rChancesLeft <= 0)
        {
            for (int i = 0; i < leftTeam.Count; i++)
            {
                if (leftTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P1")
                {
                    standing.p1 = 5;

                }
                if (leftTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P2")
                {
                    standing.p2 = 5;

                }
                if (leftTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P3")
                {
                    standing.p3 = 5;

                }
                if (leftTeam[i].GetComponent<GlockPlayerController>().playerType.ToString() == "P4")
                {
                    standing.p4 = 5;

                }
            }
            SceneManager.LoadScene(1);
        }
    }
}
