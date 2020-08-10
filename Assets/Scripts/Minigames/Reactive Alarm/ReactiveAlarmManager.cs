using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveAlarmManager : MonoBehaviour
{
    public Standing standing;

    public List<ReactiveAlarmInputter> players;

    public float timer;

    ButtonToPress BTP;

    float countdown;

    void Start()
    {
        BTP = GetComponent<ButtonToPress>();
        countdown = timer;
    }

    void Update()
    {
        if (BTP.roundCounter <= 0)
        {
            standing.p1 = players[0].score;
            standing.p2 = players[1].score;
            //standing.p3 = players[2].score;
            //standing.p4 = players[3].score;
        }

        countdown -= Time.deltaTime;

        if (BTP.UpdateButtonToPress() == "X")
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].input == "X")
                {
                    players[i].score++;
                    players[i].input = "";
                    BTP.roundCounter--;
                    BTP.ResetTimers();
                    BTP.DeactivateButtons();
                }
            }
        }
        else if (BTP.UpdateButtonToPress() == "A")
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].input == "A")
                {
                    players[i].score++;
                    players[i].input = "";
                    BTP.roundCounter--;
                    BTP.ResetTimers();
                    BTP.DeactivateButtons();
                }
            }
        }
        else if (BTP.UpdateButtonToPress() == "B")
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].input == "B")
                {
                    players[i].score++;
                    players[i].input = "";
                    BTP.roundCounter--;
                    BTP.ResetTimers();
                    BTP.DeactivateButtons();
                }
            }
        }
        else if (BTP.UpdateButtonToPress() == "Y")
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].input == "Y")
                {
                    players[i].score++;
                    players[i].input = "";
                    BTP.roundCounter--;
                    BTP.ResetTimers();
                    BTP.DeactivateButtons();
                }
            }
        }
        else if (countdown <= 0)
        {
            BTP.roundCounter--;
            countdown = timer;
        }
    }
}
