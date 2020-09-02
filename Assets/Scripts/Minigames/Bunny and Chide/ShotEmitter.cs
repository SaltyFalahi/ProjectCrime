using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotEmitter : MonoBehaviour
{
    public List<AudioClip> clips;
    
    public AudioClip shotClip;

    public bool done;

    AudioSource shotAudio;

    IEnumerator coroutine;

    float countdown = 5; //will be used for button activation and deactivation
    float shotTimer;

    int shotsToFire;
    int shotsFired;

    void Start()
    {
        shotAudio = GetComponent<AudioSource>();

        shotTimer = Random.Range(2, 6);

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

            shotAudio.clip = clips[Random.Range(0, clips.Count)];
            shotAudio.Play();

            if(shotAudio.clip == shotClip)
            {
                shotsToFire--;
            }
        }
    }

    public int SetShotCount()
    {
        return shotsFired;
    }
}
