using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyAndChideManager : MonoBehaviour
{
    public Standing standing;

    public BCPlayerControls p1;
    public BCPlayerControls p2;

    void Update()
    {
        if (p1.done && p2.done)
        {
            standing.p1 = p1.score;
            standing.p2 = p2.score;

            SceneManager.LoadScene(1);
        }
    }
}
