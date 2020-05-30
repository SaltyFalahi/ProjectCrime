using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondSpace : MonoBehaviour
{
    public GameObject panel;
    public Text dialogue;

    public int count;

    PlayerInfo player;

    void Start()
    {
        dialogue.text = "A Diamond is worth 20 bucks";
    }

    void Update()
    {
        if (panel.activeInHierarchy)
        {
            dialogue.text = "Left click to get a Diamond, Right click to cancel";
            if (player.bucks >= 20 && Input.GetMouseButtonDown(0))
            {
                dialogue.text = "Here's your Diamond!";
                player.bucks -= 20;
                player.diamonds += 1;
                panel.SetActive(false);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                dialogue.text = "You don't want the Diamond? Oh well...";

                if (Input.GetMouseButtonDown(0))
                {
                    panel.SetActive(false);
                }
            }
            else if (player.bucks < 20)
            {
                dialogue.text = "You can't afford a Diamond...";

                if (Input.GetMouseButtonDown(0))
                {
                    panel.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player walks into the space
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerInfo>();
            //Enable purchase of Diamonds
            panel.SetActive(true);
        }
    }
}
