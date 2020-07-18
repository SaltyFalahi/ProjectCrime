using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatforGenerator : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 00.0f;
        }

        timerText.text = timer.ToString("00.0" + "s");
    }
}
