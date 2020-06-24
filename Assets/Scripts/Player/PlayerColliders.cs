using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    PlayerInfo myPlayerInfo;

    int abilityIndex;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerInfo = GetComponent<PlayerInfo>();
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
            abilityIndex = Random.Range(1, 10);
            Debug.Log(abilityIndex);

            switch (abilityIndex)
            {
                case 1:
                    myPlayerInfo.sneakers++;
                    break;

                case 2:
                    myPlayerInfo.rocketShoes++;
                    break;

                case 3:
                    myPlayerInfo.moonwalkShoes++;
                    break;

                case 4:
                    myPlayerInfo.getawayVan++;
                    break;

                case 5:
                    myPlayerInfo.shovel++;
                    break;

                case 6:
                    myPlayerInfo.moneyMags++;
                    break;

                case 7:
                    myPlayerInfo.thiefGloves++;
                    break;

                case 8:
                    myPlayerInfo.iKnowAGuy++;
                    break;

                case 9:
                    myPlayerInfo.ironBall++;
                    break;

                default:
                    Debug.Log("No Item");
                    break;
            }
        }
    }
}
