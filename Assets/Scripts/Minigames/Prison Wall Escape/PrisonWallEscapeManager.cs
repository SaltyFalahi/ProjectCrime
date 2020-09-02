using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonWallEscapeManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;

    public int playersLeft = 4;

    [SerializeField]
    TextMeshProUGUI distText;

    [SerializeField]
    List<GameObject> windowRow1;
    [SerializeField]
    List<GameObject> windowRow2;
    [SerializeField]
    List<GameObject> windowRow3;
    [SerializeField]
    List<GameObject> windowRow4;
    [SerializeField]
    List<GameObject> windowRow5;
    [SerializeField]
    List<GameObject> windowRow6;

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform ground;

    float distanceToGround;
    float offSet = 4;

    // Start is called before the first frame update
    void Start()
    {
        PickWindows1();
        PickWindows2();
        PickWindows3();
        PickWindows4();
        PickWindows5();
        PickWindows6();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToGround = (Vector3.Distance(player.position, ground.position) - offSet);

        distText.text = distanceToGround.ToString("00" + "m");

        if (playersLeft <= 1)
        {
            PlayerWin();
        }
    }

    void PickWindows1()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(5, 9);
        int windowPicked4 = Random.Range(5, 9);

        windowRow1[windowPicked1].GetComponent<Renderer>().material.SetColor("Red",  Color.red);
        windowRow1[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow1[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow1[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow1[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow1[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow1[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow1[windowPicked4].GetComponent<BoxCollider>().enabled = true;
    }

    void PickWindows2()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(5, 9);
        int windowPicked4 = Random.Range(5, 9);

        windowRow2[windowPicked1].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow2[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow2[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow2[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow2[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow2[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow2[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow2[windowPicked4].GetComponent<BoxCollider>().enabled = true;
    }

    void PickWindows3()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(5, 9);
        int windowPicked4 = Random.Range(5, 9);

        windowRow3[windowPicked1].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow3[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow3[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow3[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow3[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow3[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow3[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow3[windowPicked4].GetComponent<BoxCollider>().enabled = true;
    }

    void PickWindows4()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        windowRow4[windowPicked1].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow4[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow4[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow4[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow4[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow4[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow4[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow4[windowPicked4].GetComponent<BoxCollider>().enabled = true;

        windowRow4[windowPicked5].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow4[windowPicked5].GetComponent<BoxCollider>().enabled = true;
    }

    void PickWindows5()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        windowRow5[windowPicked1].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow5[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow5[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow5[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow5[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow5[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow5[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow5[windowPicked4].GetComponent<BoxCollider>().enabled = true;

        windowRow6[windowPicked5].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked5].GetComponent<BoxCollider>().enabled = true;
    }

    void PickWindows6()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        windowRow6[windowPicked1].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked1].GetComponent<BoxCollider>().enabled = true;

        windowRow6[windowPicked2].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked2].GetComponent<BoxCollider>().enabled = true;

        windowRow6[windowPicked3].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked3].GetComponent<BoxCollider>().enabled = true;

        windowRow6[windowPicked4].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked4].GetComponent<BoxCollider>().enabled = true;

        windowRow6[windowPicked5].GetComponent<Renderer>().material.SetColor("Red", Color.red);
        windowRow6[windowPicked5].GetComponent<BoxCollider>().enabled = true;
    }

    public void PlayerWin()
    {
        if (!winPanel.activeInHierarchy)
        {
            winPanel.SetActive(true);
        }

        //add code for when the player(s) win(s)
    }
}
