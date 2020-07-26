using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrisonWallEscapeManager : MonoBehaviour
{
    public TextMeshProUGUI distText;

    public GameObject losePanel;
    public GameObject winPanel;

    public Transform player;
    public Transform ground;

    public int playersLeft = 4;

    float distanceToGround;
    float offSet = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceToGround = (Vector3.Distance(player.position, ground.position) - offSet);

        distText.text = distanceToGround.ToString("00" + "m");

        if (playersLeft <= 1)
        {
            PlayerWin();
        }
    }

    public void PlayerWin()
    {
        if (!winPanel.activeInHierarchy)
        {
            winPanel.SetActive(true);
        }

        //add code for when the player(s) win(s)
    }
}
