using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockConveyorBelt : MonoBehaviour
{
    GlockBomb gB;
    GlockManager gM;
    GlockPlayerController gPC;

    [SerializeField]
    GameObject myBomb;

    // Start is called before the first frame update
    void Start()
    {
        gB = myBomb.GetComponent<GlockBomb>();   
        gM = GameObject.FindGameObjectWithTag("MinigameManager").GetComponent<GlockManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gPC = other.gameObject.GetComponent<GlockPlayerController>();

            if (gPC.isRed && gPC.hasPressedButton && gB.directionInt == 1)
            {
                gB.directionInt = 0;
                Debug.Log("Going left");
            }

            if (gPC.isBlue && gPC.hasPressedButton && gB.directionInt == 0)
            {
                gB.directionInt = 1;
                Debug.Log("Going right");
            }

            Debug.Log("Player");
        }
    }
}
