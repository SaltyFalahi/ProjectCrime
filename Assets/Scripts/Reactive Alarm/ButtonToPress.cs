using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonToPress : MonoBehaviour
{
    public TextMeshProUGUI ButtonText;

    string[] buttons = new string[4] { "A", "B", "X", "Y" };

    string readyStr = "Ready?";

    // Start is called before the first frame update
    void Start()
    {
        ButtonText.text = readyStr.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
