using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public NumberRolled numberRolled;

    public Camera main;

    public GameObject D6;
    public GameObject D4;

    public bool diceRolled = false;
    public bool diceThrown = false;

    GameObject d1;
    GameObject d2;
    GameObject d3;

    PlayerAbilities playerAbilities;

    void Start()
    {
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    void RollD4()
    {
        diceRolled = true;
        //numberRolled = Random.Range(1, 5);
        playerAbilities.target.GetComponent<PlayerAbilities>().ironBallIsActive = false;
    }

    public void RollD6()
    {
        if (playerAbilities.ironBallIsActive)
        {
            RollD4();
        }
        d1 = Instantiate(D6);
        d1.transform.position = main.transform.position;

        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);

        d1.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d1.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);

        StartCoroutine(Timer(5, d1));
    }

    public void Roll2D6()
    {
        d1 = Instantiate(D6);
        d2 = Instantiate(D6);
        d1.transform.position = main.transform.position;
        d2.transform.position = main.transform.position;

        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);

        d1.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d2.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d1.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
        d2.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);

        StartCoroutine(Timer(5, d1, d2));
    }

    public void Roll3D6()
    {
        d1 = Instantiate(D6);
        d2 = Instantiate(D6);
        d3 = Instantiate(D6);
        d1.transform.position = main.transform.position;
        d2.transform.position = main.transform.position;
        d3.transform.position = main.transform.position;

        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);

        d1.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d2.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d3.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        d1.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
        d2.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
        d3.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);

        StartCoroutine(Timer(5, d1, d2, d3));
    }

    public IEnumerator Timer(int time, GameObject d1)
    {
        yield return new WaitForSeconds(time);
        numberRolled.value = d1.GetComponent<D6>().value;
        diceRolled = true;
    }

    public IEnumerator Timer(int time, GameObject d1, GameObject d2)
    {
        yield return new WaitForSeconds(time);
        numberRolled.value = d1.GetComponent<D6>().value + d2.GetComponent<D6>().value;
        diceRolled = true;
    }

    public IEnumerator Timer(int time, GameObject d1, GameObject d2, GameObject d3)
    {
        yield return new WaitForSeconds(time);
        numberRolled.value = d1.GetComponent<D6>().value + d2.GetComponent<D6>().value + d3.GetComponent<D6>().value;
        diceRolled = true;
    }
}