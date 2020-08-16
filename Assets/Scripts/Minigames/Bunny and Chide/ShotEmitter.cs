using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotEmitter : MonoBehaviour
{
    public bool done;

    AudioSource shotAudio;

    IEnumerator coroutine;

    float shotTimer;

    int shotsToFire;
    int shotsFired;

    void Start()
    {
        shotAudio = GetComponent<AudioSource>();

        shotTimer = Random.Range(1, 6);

        shotsToFire = Random.Range(3, 11);
        shotsFired = shotsToFire;
        Debug.Log(shotsFired);

        coroutine = StartShots(shotTimer);

        StartCoroutine(coroutine);
    }

    void Update()
    {
        if (shotsToFire <= 0)
        {
            done = true;
        }
    }

    IEnumerator StartShots(float time)
    {
        while (shotsToFire > 0)
        {
            yield return new WaitForSeconds(time);

            shotAudio.Play();
            shotsToFire--;
        }
    }

    public int SetShotCount()
    {
        return shotsFired;
    }
}
