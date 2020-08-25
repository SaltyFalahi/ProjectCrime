using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FTCGameManager : MonoBehaviour
{
    public Standing standing;

    public List<GameObject> platforms;

    public List<FallingPlayerController> players;

    public FallingPlayerController p1;
    public FallingPlayerController p2;

    IEnumerator platCoroutine;

    public int timer;

    int platformCountdown = 25;
    int counter;
    int score;

    void Start()
    {
        timer = Random.Range(6, 10);
        platCoroutine = DropPlatform(timer);

        StartCoroutine(platCoroutine);
    }

    void Update()
    {
        if (counter > players.Count)
        {
            standing.p1 = players[0].score;
            standing.p2 = players[1].score;

            SceneManager.LoadScene(1);
        }
    }

    IEnumerator DropPlatform(int waitTime)
    {
        while (platformCountdown >= 1)
        {
            yield return new WaitForSeconds(waitTime);

            int ranPlatform = Random.Range(0, platforms.Count);
            int destroyTime = 2;

            platforms[ranPlatform].GetComponent<Rigidbody>().useGravity = true;
                platforms[ranPlatform].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    

            yield return new WaitForSeconds(destroyTime);

            platformCountdown--;

            Destroy(platforms[ranPlatform]);
            platforms.RemoveAt(ranPlatform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (other.gameObject.GetComponent<FallingPlayerController>() == players[i])
                {
                    players[i].score = score;
                }
            }
            counter++;
            score++;
            other.gameObject.SetActive(false);
        }
    }
}
