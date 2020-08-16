using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonToPress : MonoBehaviour
{
    public GameObject buttonObj;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI roundText;

    public int roundCounter;

    public string buttonPicked;

    float countdown = 5;
    float coolDown = 10;

    string[] buttons = new string[] { "A", "B", "X", "Y" };

    void Update()
    {
        if (countdown <= 5 && coolDown >= 10)
        {
            countdown -= Time.deltaTime;
            buttonText.text = countdown.ToString("0");
            roundText.text = roundCounter.ToString("0");
        }

        if (countdown <= 0 && coolDown >= 10 && !buttonObj.activeInHierarchy)
        {
            int pickButton = Random.Range(0, buttons.Length);

            buttonObj.SetActive(true);

            buttonPicked = buttons[pickButton];

            buttonText.text = buttonPicked.ToString();

            coolDown -= Time.deltaTime;
        }
    }

    public string UpdateButtonToPress()
    {
        return buttonPicked;
    }

    public void ResetTimers()
    {
        countdown = 5;
        coolDown = 10;
    }

    public void DeactivateButtons()
    {
        if (buttonObj.activeInHierarchy)
        {
            buttonObj.SetActive(false);
        }
    }
}
