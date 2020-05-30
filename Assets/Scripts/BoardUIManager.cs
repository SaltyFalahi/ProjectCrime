using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIManager : MonoBehaviour
{
    public Camera boardCam;

    public GameObject boardPlayerCamPoint;
    public GameObject boardMapCamPoint;
    public GameObject mainPanel;
    public GameObject dicePanel;
    public GameObject itemsPanel;

    public void OpenDicePanel()
    {
        if (!dicePanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(true);
            itemsPanel.SetActive(false);
        }
    }

    public void OpenItemsPanel()
    {
        if (!itemsPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(true);
        }
    }

    public void OpenMainPanel()
    {
        if (!mainPanel.activeInHierarchy)
        {
            mainPanel.SetActive(true);
            dicePanel.SetActive(false);
            itemsPanel.SetActive(false);
        }
    }

    public void OpenBoardMapMode()
    {
        
    }

    public void ReturnToPlayerCamMode()
    {

    }
}
