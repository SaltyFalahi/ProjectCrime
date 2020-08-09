using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardController : MonoBehaviour
{
    public static BoardController _instance;

    public NumberRolled dice;
    public PlayerData p1;
    public PlayerData p2;
    public Standing stand;

    public BoardData bd;

    public bool loaded = true;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetScriptableObjects();
    }

    void Update()
    {
        bd = GameObject.FindGameObjectWithTag("BoardData").GetComponent<BoardData>();

        if (SceneManager.GetActiveScene().buildIndex == 0 && !loaded)
        {
            bd.LoadPlayers();
            loaded = true;
        }
    }

    void ResetScriptableObjects()
    {
        dice.value = 0;

        p1.tilePoints.Clear();

        p1.position = new Vector3((float)-2.85, (float)1.28, (float)-12.7);

        p1.bucks = 0;
        p1.diamonds = 0;
        p1.sneakers = 0;
        p1.rocketShoes = 0;
        p1.moonwalkShoes = 0;
        p1.getawayVan = 0;
        p1.shovel = 0;
        p1.moneyMags = 0;
        p1.thiefGloves = 0;
        p1.iKnowAGuy = 0;
        p1.ironBall = 0;
        p1.index = 0;

        p1.tilePoints.Clear();

        p2.position = new Vector3((float)3.15, (float)1.28, (float)-12.7);
         
        p2.bucks = 0;
        p2.diamonds = 0;
        p2.sneakers = 0;
        p2.rocketShoes = 0;
        p2.moonwalkShoes = 0;
        p2.getawayVan = 0;
        p2.shovel = 0;
        p2.moneyMags = 0;
        p2.thiefGloves = 0;
        p2.iKnowAGuy = 0;
        p2.ironBall = 0;
        p2.index = 0;

        stand.standings.Clear();

        stand.p1=0;
        stand.p2=0;
        stand.p3=0;
        stand.p4=0;
    }
}
