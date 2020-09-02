using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BoardUIManager : MonoBehaviour
{
    [Header("Camera Objects")]
    public GameObject boardCam;
    public GameObject boardPlayerCamPoint;
    public GameObject boardSideMapCamPoint;
    public GameObject boardTopMapCamPoint;

    [Header("Panels")]
    public GameObject dicePanel;
    public GameObject directionPanel;
    public GameObject itemsPanel;
    public GameObject itemShopPanel;
    public GameObject pausePanel;
    public GameObject playerSelectPanel;    
    public GameObject mainPanel;
    public GameObject mapSelectionPanel;
    public GameObject sidemapControlPanel;

    [Header("First Panel Buttons")]
    public GameObject diceFirstButton;
    public GameObject directionFirstButton;
    public GameObject itemFirstButton;
    public GameObject mainFirstButton;
    public GameObject mapSelectFirstButton;
    public GameObject pauseFirstButton;
    public GameObject playerSelectFirstButton;
    public GameObject shopFirstButton;

    [Header("Texts")]
    [SerializeField]
    TextMeshProUGUI diamonds;
    [SerializeField]
    TextMeshProUGUI bucksLeft;
    [SerializeField]
    TextMeshProUGUI sneakersLeft;
    [SerializeField]
    TextMeshProUGUI rocketsLeft;
    [SerializeField]
    TextMeshProUGUI shovelsLeft;
    [SerializeField]
    TextMeshProUGUI glovesLeft;
    [SerializeField]
    TextMeshProUGUI magnetsLeft;
    [SerializeField]
    TextMeshProUGUI iKnowAGuysLeft;
    [SerializeField]
    TextMeshProUGUI vansLeft;
    [SerializeField]
    TextMeshProUGUI ironBallsLeft;

    [Header("Script Referencing")]
    [SerializeField]
    PlayerInfo pInfo;
    [SerializeField]
    PlayerColliders pCols;

    bool camIsPlayer = true;
    bool camIsSide = false;
    bool camIsTop = false;

    float speed;

    [Header("Shop Costs")]
    [SerializeField]
    int sneakersCost;
    [SerializeField]
    int glovesCost;
    [SerializeField]
    int diamondCost;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    void Update()
    {
        if (camIsPlayer || !mapSelectionPanel.activeInHierarchy)
        {
            ReturnToPlayerCamMode();
        }
        else if (camIsSide)
        {
            ChangeToSideCamMode();
        }
        else if (camIsTop)
        {
            ChangeToTopCamMode();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            OpenClosePauseMenu();
        }

        diamonds.text = pInfo.diamonds.ToString("00");
        bucksLeft.text = pInfo.bucks.ToString("00");
        sneakersLeft.text = "Sneakers: " + pInfo.sneakers.ToString("00");
        rocketsLeft.text = "Rocket Shoes: " + pInfo.rocketShoes.ToString("00");
        shovelsLeft.text = "Shovels: " + pInfo.shovel.ToString("00");
        glovesLeft.text = "Thief's Gloves: " + pInfo.thiefGloves.ToString("00");
        magnetsLeft.text = "Money Magnets: " + pInfo.moneyMags.ToString("00");
        iKnowAGuysLeft.text = "I Know A Guy: " + pInfo.iKnowAGuy.ToString("00");
        vansLeft.text = "Getaway Vans: " + pInfo.getawayVan.ToString("00");
        ironBallsLeft.text = "Iron Balls: " + pInfo.ironBall.ToString("00");
    }

    public void SetShopFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(shopFirstButton);
    }

    //item shop
    public void BuySneakers()
    {
        if (pInfo.bucks >= sneakersCost)
        {
            pInfo.bucks -= sneakersCost;
            pInfo.sneakers++;
        }
    }

    public void BuyGloves()
    {
        if (pInfo.bucks >= glovesCost)
        {
            pInfo.bucks -= glovesCost;
            pInfo.thiefGloves++;
        }
    }

    public void BuyDiamond()
    {
        if (pInfo.bucks >= diamondCost)
        {
            pInfo.bucks -= diamondCost;
            pInfo.diamonds++;
        }
    }

    //panels
    public void OpenClosePauseMenu()
    {
        if (!pausePanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            pausePanel.SetActive(true);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else
        {
            pausePanel.SetActive(false);

            OpenMainPanel();
        }
    }

    public void OpenMainPanel()
    {
        if (!mainPanel.activeInHierarchy)
        {
            mainPanel.SetActive(true);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            itemShopPanel.SetActive(false);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(mainFirstButton);
        }
    }

    public void OpenDicePanel()
    {
        if (!dicePanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(true);
            itemsPanel.SetActive(false);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(diceFirstButton);
        }
    }

    public void OpenItemsPanel()
    {
        if (!itemsPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(true);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(itemFirstButton);
        }
    }

    public void OpenPlayerSelectPanel()
    {
        if (!playerSelectPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            playerSelectPanel.SetActive(true);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(playerSelectFirstButton);
        }
    }

    public void OpenMapSelectionPanel()
    {
        if (!mapSelectionPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(true);
            directionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(mapSelectFirstButton);
        }
    }

    public void OpenDirectionPanel()
    {
        if (!directionPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            playerSelectPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            directionPanel.SetActive(true);
            sidemapControlPanel.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(directionFirstButton);
        }
    }

    //camera controls
    public void ReturnToPlayerCamMode()
    {
        camIsPlayer = true;
        camIsSide = false;
        camIsTop = false;

        if (boardCam.transform.position != boardPlayerCamPoint.transform.position || camIsPlayer)
        {
            speed = 0.05f;
            boardCam.transform.position = Vector3.Lerp(boardCam.transform.position, boardPlayerCamPoint.transform.position, speed);
        }
        else
        {
            camIsPlayer = false;
            speed = 0;
        }

        boardCam.transform.eulerAngles = new Vector3(boardPlayerCamPoint.transform.eulerAngles.x,
            boardPlayerCamPoint.transform.eulerAngles.y, boardPlayerCamPoint.transform.eulerAngles.z);
    }

    public void ChangeToSideCamMode()
    {
        camIsPlayer = false;
        camIsSide = true;
        camIsTop = false;

        if (boardCam.transform.position != boardSideMapCamPoint.transform.position)
        {
            speed = 0.005f;
            boardCam.transform.position = Vector3.Lerp(boardCam.transform.position, boardSideMapCamPoint.transform.position, speed);
        }
        else
        {
            camIsSide = false;
            speed = 0;
        }

        boardCam.transform.eulerAngles = new Vector3(boardSideMapCamPoint.transform.eulerAngles.x,
            boardSideMapCamPoint.transform.eulerAngles.y, boardSideMapCamPoint.transform.eulerAngles.z);
    }

    public void ChangeToTopCamMode()
    {
        camIsPlayer = false;
        camIsSide = false;
        camIsTop = true;

        if (boardCam.transform.position != boardTopMapCamPoint.transform.position)
        {
            speed = 0.005f;
            boardCam.transform.position = Vector3.Lerp(boardCam.transform.position, boardTopMapCamPoint.transform.position, speed);
        }
        else
        {
            camIsTop = false;
            speed = 0;
        }

        boardCam.transform.eulerAngles = new Vector3(boardTopMapCamPoint.transform.eulerAngles.x,
            boardTopMapCamPoint.transform.eulerAngles.y, boardTopMapCamPoint.transform.eulerAngles.z);
    }
}