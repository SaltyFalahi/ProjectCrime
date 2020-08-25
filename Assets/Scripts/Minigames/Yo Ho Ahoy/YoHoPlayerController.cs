using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoHoPlayerController : MonoBehaviour
{
    YoHoAhoyManager yHAM;

    public enum player
    {
        P1,
        P2,
        P3,
        P4
    }

    public player type;

    [SerializeField]
    bool isHider;

    bool hasPicked = false;

    string buttonA;
    string buttonB;
    string buttonX;
    string buttonY;

    // Start is called before the first frame update
    void Start()
    {
        yHAM = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<YoHoAhoyManager>();

        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHider && yHAM.picksLeft >= 1)
        {
            if (Input.GetButtonDown(buttonA) && yHAM.pickingRound && yHAM.cannon1Players.Count >= 1)
            {
                yHAM.playersCaught.AddRange(yHAM.cannon1Players);
                yHAM.cannon1Players.Clear();
                yHAM.picksLeft--;
            }

            if (Input.GetButtonDown(buttonB) && yHAM.pickingRound && yHAM.cannon2Players.Count >= 1)
            {
                yHAM.playersCaught.AddRange(yHAM.cannon2Players);
                yHAM.cannon2Players.Clear();
                yHAM.picksLeft--;
            }

            if (Input.GetButtonDown(buttonX) && yHAM.pickingRound && yHAM.cannon3Players.Count >= 1)
            {
                yHAM.playersCaught.AddRange(yHAM.cannon3Players);
                yHAM.cannon3Players.Clear();
                yHAM.picksLeft--;
            }

            if (Input.GetButtonDown(buttonY) && yHAM.pickingRound && yHAM.cannon4Players.Count >= 1)
            {
                yHAM.playersCaught.AddRange(yHAM.cannon4Players);
                yHAM.cannon4Players.Clear();
                yHAM.picksLeft--;
            }
        }
        
        if(isHider)
        {
            if (Input.GetButtonDown(buttonA) && !hasPicked)
            {
                yHAM.playersPicking--;
                hasPicked = true;
                yHAM.cannon1Players.Add(gameObject);
            }

            if (Input.GetButtonDown(buttonB) && !hasPicked)
            {
                yHAM.playersPicking--;
                hasPicked = true;
                yHAM.cannon2Players.Add(gameObject);
            }

            if (Input.GetButtonDown(buttonX) && !hasPicked)
            {
                yHAM.playersPicking--;
                hasPicked = true;
                yHAM.cannon3Players.Add(gameObject);
            }

            if (Input.GetButtonDown(buttonY) && !hasPicked)
            {
                yHAM.playersPicking--;
                hasPicked = true;
                yHAM.cannon4Players.Add(gameObject);
            }

            if (!yHAM.hidingRound && !yHAM.pickingRound && !hasPicked && isHider)
            {
                int ranList = Random.Range(1, 5);

                switch (ranList)
                {
                    case 1:
                        hasPicked = true;
                        yHAM.cannon1Players.Add(gameObject);
                        break;

                    case 2:
                        hasPicked = true;
                        yHAM.cannon2Players.Add(gameObject);
                        break;

                    case 3:
                        hasPicked = true;
                        yHAM.cannon3Players.Add(gameObject);
                        break;

                    case 4:
                        hasPicked = true;
                        yHAM.cannon4Players.Add(gameObject);
                        break;
                }

                yHAM.playersPicking = 0;
            }
        }
    }

    void GetPlayer()
    {
        switch (type)
        {
            case player.P1:
                buttonA = "P1Fire1";
                buttonB = "P1Fire2";
                buttonX = "P1Fire3";
                buttonY = "P1Fire4";
                break;

            case player.P2:
                buttonA = "P2Fire1";
                buttonB = "P2Fire2";
                buttonX = "P2Fire3";
                buttonY = "P2Fire4";
                break;

            case player.P3:
                buttonA = "P3Fire1";
                buttonB = "P3Fire2";
                buttonX = "P3Fire3";
                buttonY = "P3Fire4";
                break;

            case player.P4:
                buttonA = "P4Fire1";
                buttonB = "P4Fire2";
                buttonX = "P4Fire3";
                buttonY = "P4Fire4";
                break;
        }
    }
}
