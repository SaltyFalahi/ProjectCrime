using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardUIManager : MonoBehaviour
{
    //camera
    public GameObject boardCam;
    public GameObject boardPlayerCamPoint;
    public GameObject boardSideMapCamPoint;
    public GameObject boardTopMapCamPoint;

    //panels
    public GameObject dicePanel;
    public GameObject directionPanel;
    public GameObject itemsPanel;
    public GameObject pausePanel;
    public GameObject playerSelectPanel;    
    public GameObject mainPanel;
    public GameObject mapSelectionPanel;
    public GameObject sidemapControlPanel;

    //first panel buttons
    public GameObject pauseFirstButton;
    public GameObject mainFirstButton;
    public GameObject diceFirstButton;
    public GameObject itemFirstButton;
    public GameObject playerSelectFirstButton;
    public GameObject mapSelectFirstButton;
    public GameObject directionFirstButton;

    bool camIsPlayer = true;
    bool camIsSide = false;
    bool camIsTop = false;

    float speed;

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
    }

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
