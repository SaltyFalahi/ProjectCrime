using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YoHoAhoyManager : MonoBehaviour
{
    public TextMeshProUGUI roundTypeText;
    public TextMeshProUGUI roundTypeTimer;
    public TextMeshProUGUI pickLeftText;

    public bool hidingRound = true;
    public bool pickingRound = false;
    public bool cooldownRound = false;
    //public bool allHidersDone = false;
    
    public int playersPicking = 3;
    public int picksLeft = 3;

    [SerializeField]
    GameObject buttonsPanel;

    public List<GameObject> cannon1Players;
    public List<GameObject> cannon2Players;
    public List<GameObject> cannon3Players;
    public List<GameObject> cannon4Players;

    public List<GameObject> playersCaught;

    [SerializeField]
    float roundTimer;
    float cooldownTimer = 5;

    string hRound = "Hiding Round";
    string pRound = "Picking Round";
    string cRound = "Cooldown Round";

    // Start is called before the first frame update
    void Start()
    {
        roundTypeText.text = hRound;
    }

    // Update is called once per frame
    void Update()
    {
        roundTimer -= Time.deltaTime;

        roundTypeTimer.text = roundTimer.ToString("00" + "s");
        pickLeftText.text = picksLeft.ToString("0");

        if (playersPicking <= 0 || roundTimer <= 0 && !pickingRound && hidingRound && !cooldownRound)
        {
            roundTimer = cooldownTimer;

            roundTypeText.text = cRound;

            playersPicking = 3;

            hidingRound = false;
            cooldownRound = true;
        }

        if (roundTimer <= 0 && !pickingRound && cooldownRound)
        {
            roundTimer = 60;

            pickingRound = true;
            cooldownRound = false;

            roundTypeText.text = pRound;
        }

        if (cooldownRound)
        {
            buttonsPanel.SetActive(false);
        }
        else
        {
            buttonsPanel.SetActive(true);
        }

        if (playersCaught.Count >= 3 && picksLeft != 0)
        {
            //seeker wins
        }

        if (picksLeft <= 0 && playersCaught.Count != 3)
        {
            picksLeft = 0;
            //hiders win
        }
    }
}
