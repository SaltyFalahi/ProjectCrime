using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonToPress : MonoBehaviour
{
    public GameObject ButtonObj;
    public TextMeshProUGUI ButtonText;

    public string buttonPicked;

    float countdown = 5;
    float coolDown = 10;

    string[] buttons = new string[] { "A", "B", "X", "Y" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 5 && coolDown >= 10)
        {
            countdown -= Time.deltaTime;
            ButtonText.text = countdown.ToString("0");
        }

        if (countdown <= 0 && coolDown >= 10 && !ButtonObj.activeInHierarchy)
        {
            int pickButton = Random.Range(0, buttons.Length);

            ButtonObj.SetActive(true);

            buttonPicked = buttons[pickButton];

            ButtonText.text = buttonPicked.ToString();

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
        if (ButtonObj.activeInHierarchy)
        {
            ButtonObj.SetActive(false);
        }
    }
}
