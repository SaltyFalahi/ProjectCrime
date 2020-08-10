﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;

    ButtonToPress BTP;

    int playerScore;

    void Start()
    {
        BTP = GetComponent<ButtonToPress>();
    }

    void Update()
    {
        scoretxt.text = playerScore.ToString("00");
    }

    public void PressButtonY(string buttonToPress)
    {
        buttonToPress = "Y";

        if (buttonToPress == BTP.UpdateButtonToPress())
        {
            playerScore++;

            BTP.roundCounter++;

            Debug.Log(buttonToPress + " is correct!");
        }
        else
        {
            BTP.roundCounter++;

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

            BTP.roundCounter++;

            Debug.Log(buttonToPress + " is correct!");
        }
        else
        {
            BTP.roundCounter++;

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

            BTP.roundCounter++;

            Debug.Log(buttonToPress + " is correct!");
        }
        else
        {
            BTP.roundCounter++;

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

            BTP.roundCounter++;

            Debug.Log(buttonToPress + " is correct!");
        }
        else
        {
            BTP.roundCounter++;
             
            Debug.Log("Wrong one, bucko!");
        }

        BTP.ResetTimers();
        BTP.DeactivateButtons();
    }

}
