using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotPotatoManager : MonoBehaviour
{
    public Standing standing;

    public List<GameObject> players;

    public GameObject bomb;
    public GameObject player;

    public float timer;
    public float cooldownTimer;

    [SerializeField]
    float bombOffset;
    float countdown;
    float cooldownCountdown;

    int score = 0;

    void Start()
    {
        countdown = timer;
        SpawnBomb();
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        cooldownCountdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            switch (player.name)
            {
                case "Player 1":
                    standing.p1 = score;
                    score++;
                    break;

                case "Player 2":
                    standing.p2 = score;
                    score++;
                    break;

                case "Player 3":
                    standing.p3 = score;
                    score++;
                    break;

                case "Player 4":
                    standing.p4 = score;
                    score++;
                    break;
            }

            players.Remove(player);
            Destroy(player);
            SpawnBomb();
        }

        bomb.transform.position = new Vector3(player.transform.position.x, 
            player.transform.position.y + bombOffset, player.transform.position.z);
    }

    void SpawnBomb()
    {
        if (players.Count > 1)
        {
            player = players[Random.Range(0, players.Count)];
            countdown = timer;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PassBomb(GameObject obj)
    {
        if (cooldownCountdown <= 0)
        {
            player = obj;
            cooldownCountdown = cooldownTimer;
        }
    }
}
