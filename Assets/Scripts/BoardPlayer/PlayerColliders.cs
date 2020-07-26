using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    PlayerInfo myPlayerInfo;
    PlayerAbilities playerAbilities;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerInfo = GetComponent<PlayerInfo>();
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision objCol)
    {
        if (objCol.gameObject.tag.Equals("Diamond"))
        {
            myPlayerInfo.diamonds++;
            Destroy(objCol.gameObject);
        }

        if (objCol.gameObject.tag.Equals("ItemSpace"))
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
}
