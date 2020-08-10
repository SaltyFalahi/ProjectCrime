using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BCPlayerControls : MonoBehaviour
{
    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    public string add;
    public string subtract;
    public string confirm;

    public TextMeshProUGUI scoretxt;

    public ShotEmitter SE;

    public GameObject winText;
    public GameObject loseText;

    public int score;

    public bool done;

    int shotCount;

    float timer = 500;

    void Start()
    {
        GetPlayer();
    }

    void Update()
    {
        scoretxt.text = shotCount.ToString("00");
        
        if (SE.done)
        {
            if (Input.GetButtonDown(add))
            {
                shotCount++;
            }
            if (Input.GetButtonDown(subtract))
            {
                shotCount--;
            }
            if (Input.GetButtonDown(confirm))
            {
                ConfirmAnswer();
            }
        }
        timer -= Time.deltaTime;
    }

    public void ConfirmAnswer()
    {
        if (shotCount == SE.SetShotCount())
        {
            winText.SetActive(true);
            score = (int)timer;
        }
        else
        {
            loseText.SetActive(true);
            score = 0;
        }
        done = true;
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                add = "P1Fire1";
                subtract = "P1Fire3";
                confirm = "P1Fire2";
                break;

            case player.P2:
                add = "P2Fire1";
                subtract = "P2Fire3";
                confirm = "P2Fire2";
                break;

            case player.P3:
                add = "P3Fire1";
                subtract = "P3Fire3";
                confirm = "P3Fire2";
                break;

            case player.P4:
                add = "P4Fire1";
                subtract = "P4Fire3";
                confirm = "P4Fire2";
                break;
        }
    }
}
