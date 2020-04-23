using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    ButtonToPress BTP;

    public TextMeshProUGUI scoretxt;

    int playerScore;

    void Start()
    {
        BTP = GetComponent<ButtonToPress>();
    }

    void Update()
    {
        scoretxt.text = playerScore.ToString("Score: " + "00");
    }

    public void PressButtonY(string buttonToPress)
    {
        buttonToPress = "Y";

        if (buttonToPress == BTP.UpdateButtonToPress())
        {
            playerScore++;

            Debug.Log(buttonToPress+ "is correct!");
        }
        else
        {
            Debug.Log("Wrong one, bucko!");
        }

        BTP.ResetTimers();
        BTP.DeactivateButtons();
    }

    public void PressButtonB(string buttonToPress)
    {
        buttonToPress = "B";

        if (buttonToPress == BTP.UpdateButtonToPress())
        {
            playerScore++;

            Debug.Log("B is correct!");
        }
        else
        {
            Debug.Log("Wrong one, bucko!");
        }

        BTP.ResetTimers();
        BTP.DeactivateButtons();
    }

    public void PressButtonA(string buttonToPress)
    {
        buttonToPress = "A";

        if (buttonToPress == BTP.UpdateButtonToPress())
        {
            playerScore++;

            Debug.Log("A is correct!");
        }
        else
        {
            Debug.Log("Wrong one, bucko!");
        }

        BTP.ResetTimers();
        BTP.DeactivateButtons();
    }

    public void PressButtonX(string buttonToPress)
    {
        buttonToPress = "X";

        if (buttonToPress == BTP.UpdateButtonToPress())
        {
            playerScore++;

            Debug.Log("X is correct!");
        }
        else
        {
            playerScore++;

            Debug.Log("Wrong one, bucko!");
        }

        BTP.ResetTimers();
        BTP.DeactivateButtons();
    }
}
