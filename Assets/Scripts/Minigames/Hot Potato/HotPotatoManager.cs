using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotatoManager : MonoBehaviour
{
    public List<GameObject> players;

    public GameObject bomb;
    public GameObject player;

    public float timer;

    [SerializeField]
    float bombOffset;

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

        bomb.transform.position = transform.forward + new Vector3(player.transform.position.x, 
            player.transform.position.y, player.transform.position.z + bombOffset);
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

            countdown = 100;

            Debug.Log(player.name + " Won");
        }
    }

    public void PassBomb(GameObject obj)
    {
        player = obj;
    }
}
