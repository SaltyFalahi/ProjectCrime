using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotato : MonoBehaviour
{
    public List<GameObject> players;

    public GameObject bomb;
    public GameObject player;

    public float timer;

    float countdown;

    void Start()
    {
        countdown = timer;
        SpawnBomb();
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            players.Remove(player);
            Destroy(player);
            SpawnBomb();
        }

        bomb.transform.position = new Vector3(player.transform.position.x, 5, player.transform.position.z);
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
            player = players[0];
            Debug.Log(player.name + " Won");
        }
    }

    public void PassBomb(GameObject obj)
    {
        player = obj;
    }
}
