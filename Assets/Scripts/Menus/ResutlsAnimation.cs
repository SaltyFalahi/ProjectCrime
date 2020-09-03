using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResutlsAnimation : MonoBehaviour
{
    public bool isWinner;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (!isWinner)
        {
            anim.SetBool("isLoser", true);
        }
        else
        {
            anim.SetBool("isWinner", true);
        }
    }
}
