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

    public float speed;

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
        boardCam.transform.position = new Vector3(boardPlayerCamPoint.transform.position.x,
            boardPlayerCamPoint.transform.position.y, boardPlayerCamPoint.transform.position.z);
        boardCam.transform.eulerAngles = new Vector3(boardPlayerCamPoint.transform.eulerAngles.x,
            boardPlayerCamPoint.transform.eulerAngles.y, boardPlayerCamPoint.transform.eulerAngles.z);
    }

    public void ChangeToSideCamMode()
    {
        boardCam.transform.position = new Vector3(boardSideMapCamPoint.transform.position.x,
            boardSideMapCamPoint.transform.position.y, boardSideMapCamPoint.transform.position.z);
        boardCam.transform.eulerAngles = new Vector3(boardSideMapCamPoint.transform.eulerAngles.x,
            boardSideMapCamPoint.transform.eulerAngles.y, boardSideMapCamPoint.transform.eulerAngles.z);

        if (!sidemapControlPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
            mapSelectionPanel.SetActive(false);
            sidemapControlPanel.SetActive(true);
        }
    }

    public void ChangeToTopCamMode()
    {
        boardCam.transform.position = new Vector3(boardTopMapCamPoint.transform.position.x,
            boardTopMapCamPoint.transform.position.y, boardTopMapCamPoint.transform.position.z);
        boardCam.transform.eulerAngles = new Vector3(boardTopMapCamPoint.transform.eulerAngles.x,
            boardTopMapCamPoint.transform.eulerAngles.y, boardTopMapCamPoint.transform.eulerAngles.z);
    }
}
