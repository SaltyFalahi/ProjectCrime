using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTCGameManager : MonoBehaviour
{
    public List<GameObject> platforms;

    IEnumerator platCoroutine;

    public int timer;

    int platformCountdown = 25;
    int playerCounter = 4;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTimer();

        platCoroutine = DropPlatform(timer);

        StartCoroutine(platCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        //code to do leaderboard
    }

    void ChangeTimer()
    {
        timer = Random.Range(1, 10);
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
            ChangeTimer();

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
            playerCounter--;
            Destroy(other.gameObject);
        }
    }
}
