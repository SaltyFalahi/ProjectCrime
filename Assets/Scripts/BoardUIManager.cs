using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIManager : MonoBehaviour
{
    //camera
    public GameObject boardCam;
    public GameObject boardPlayerCamPoint;
    public GameObject boardSideMapCamPoint;
    public GameObject boardTopMapCamPoint;

    //panels
    public GameObject mainPanel;
    public GameObject dicePanel;
    public GameObject itemsPanel;
    public GameObject mapSelectionPanel;
    public GameObject sidemapControlPanel;

    

    float speed;

    bool camIsPlayer = true;
    bool camIsSide = false;
    bool camIsTop = false;

    void Update()
    {
        if (camIsPlayer)
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
    }

    public void OpenDicePanel()
    {
        if (!dicePanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(true);
            itemsPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);
        }
    }

    public void OpenItemsPanel()
    {
        if (!itemsPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(true);
            mapSelectionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);
        }
    }

    public void OpenMainPanel()
    {
        if (!mainPanel.activeInHierarchy)
        {
            mainPanel.SetActive(true);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            sidemapControlPanel.SetActive(false);
        }
    }

    public void OpenMapSelectionPanel()
    {
        if (!mapSelectionPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            mapSelectionPanel.SetActive(true);
            sidemapControlPanel.SetActive(false);
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
