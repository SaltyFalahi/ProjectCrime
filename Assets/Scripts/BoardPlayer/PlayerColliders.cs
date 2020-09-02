using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    [SerializeField]
    BoardUIManager bUIM;

    PlayerInfo myPlayerInfo;
    PlayerAbilities playerAbilities;

    float timer = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerInfo = GetComponent<PlayerInfo>();
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
    }

    void OnCollisionEnter(Collision objCol)
    {
        if (objCol.gameObject.tag.Equals("ItemBlob"))
        {
            switch (Random.Range(1, 10))
            {
                case 1:
                    playerAbilities.itemList.Add(1);
                    myPlayerInfo.sneakers++;
                    break;

                case 2:
                    playerAbilities.itemList.Add(2);
                    myPlayerInfo.rocketShoes++;
                    break;

                case 3:
                    playerAbilities.itemList.Add(3);
                    myPlayerInfo.moonwalkShoes++;
                    break;

                case 4:
                    playerAbilities.itemList.Add(4);
                    myPlayerInfo.getawayVan++;
                    break;

                case 5:
                    playerAbilities.itemList.Add(5);
                    myPlayerInfo.shovel++;
                    break;

                case 6:
                    playerAbilities.itemList.Add(6);
                    myPlayerInfo.moneyMags++;
                    break;

                case 7:
                    playerAbilities.itemList.Add(7);
                    myPlayerInfo.thiefGloves++;
                    break;

                case 8:
                    playerAbilities.itemList.Add(8);
                    myPlayerInfo.iKnowAGuy++;
                    break;

                case 9:
                    playerAbilities.itemList.Add(9);
                    myPlayerInfo.ironBall++;
                    break;

                default:
                    Debug.Log("No Item");
                    break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            timer = 2.5f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Shop") && !bUIM.mainPanel.activeInHierarchy)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && !bUIM.itemShopPanel.activeInHierarchy)
            {
                bUIM.mainPanel.SetActive(false);
                bUIM.dicePanel.SetActive(false);
                bUIM.itemsPanel.SetActive(false);
                bUIM.itemShopPanel.SetActive(true);
                bUIM.playerSelectPanel.SetActive(false);
                bUIM.mapSelectionPanel.SetActive(false);
                bUIM.directionPanel.SetActive(false);
                bUIM.sidemapControlPanel.SetActive(false);

                bUIM.SetShopFirstButton();
            }
        }
    }
}
