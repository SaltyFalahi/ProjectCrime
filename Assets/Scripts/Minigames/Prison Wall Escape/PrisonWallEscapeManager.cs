using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonWallEscapeManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;

    public int playersLeft = 4;

    public float distanceToGround;
    public float speedPoint;

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
    GameObject copWindow;
    [SerializeField]
    Transform ground;
    [SerializeField]
    List<Transform> players;

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
        for (int i = 0; i < players.Count; i++)
        {
            distanceToGround = (Vector3.Distance(players[i].position, ground.position) - offSet);
        }

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

        Instantiate(copWindow, windowRow1[windowPicked1].transform.position, windowRow1[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow1[windowPicked2].transform.position, windowRow1[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow1[windowPicked3].transform.position, windowRow1[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow1[windowPicked4].transform.position, windowRow1[windowPicked4].transform.rotation);

        Destroy(windowRow1[windowPicked1]);
        Destroy(windowRow1[windowPicked2]);
        Destroy(windowRow1[windowPicked3]);
        Destroy(windowRow1[windowPicked4]);
    }

    void PickWindows2()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(5, 9);
        int windowPicked4 = Random.Range(5, 9);

        Instantiate(copWindow, windowRow2[windowPicked1].transform.position, windowRow2[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow2[windowPicked2].transform.position, windowRow2[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow2[windowPicked3].transform.position, windowRow2[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow2[windowPicked4].transform.position, windowRow2[windowPicked4].transform.rotation);

        Destroy(windowRow2[windowPicked1]);
        Destroy(windowRow2[windowPicked2]);
        Destroy(windowRow2[windowPicked3]);
        Destroy(windowRow2[windowPicked4]);
    }

    void PickWindows3()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        Instantiate(copWindow, windowRow3[windowPicked1].transform.position, windowRow3[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow3[windowPicked2].transform.position, windowRow3[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow3[windowPicked3].transform.position, windowRow3[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow3[windowPicked4].transform.position, windowRow3[windowPicked4].transform.rotation);
        Instantiate(copWindow, windowRow3[windowPicked5].transform.position, windowRow3[windowPicked5].transform.rotation);

        Destroy(windowRow3[windowPicked1]);
        Destroy(windowRow3[windowPicked2]);
        Destroy(windowRow3[windowPicked3]);
        Destroy(windowRow3[windowPicked4]);
        Destroy(windowRow3[windowPicked5]);
    }

    void PickWindows4()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        Instantiate(copWindow, windowRow4[windowPicked1].transform.position, windowRow4[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow4[windowPicked2].transform.position, windowRow4[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow4[windowPicked3].transform.position, windowRow4[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow4[windowPicked4].transform.position, windowRow4[windowPicked4].transform.rotation);
        Instantiate(copWindow, windowRow4[windowPicked5].transform.position, windowRow4[windowPicked5].transform.rotation);

        Destroy(windowRow4[windowPicked1]);
        Destroy(windowRow4[windowPicked2]);
        Destroy(windowRow4[windowPicked3]);
        Destroy(windowRow4[windowPicked4]);
        Destroy(windowRow4[windowPicked5]);
    }

    void PickWindows5()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        Instantiate(copWindow, windowRow5[windowPicked1].transform.position, windowRow5[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow5[windowPicked2].transform.position, windowRow5[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow5[windowPicked3].transform.position, windowRow5[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow5[windowPicked4].transform.position, windowRow5[windowPicked4].transform.rotation);
        Instantiate(copWindow, windowRow5[windowPicked5].transform.position, windowRow5[windowPicked5].transform.rotation);

        Destroy(windowRow5[windowPicked1]);
        Destroy(windowRow5[windowPicked2]);
        Destroy(windowRow5[windowPicked3]);
        Destroy(windowRow5[windowPicked4]);
        Destroy(windowRow5[windowPicked5]);
    }

    void PickWindows6()
    {
        int windowPicked1 = Random.Range(1, 3);
        int windowPicked2 = Random.Range(3, 5);
        int windowPicked3 = Random.Range(3, 5);
        int windowPicked4 = Random.Range(5, 9);
        int windowPicked5 = Random.Range(5, 9);

        Instantiate(copWindow, windowRow6[windowPicked1].transform.position, windowRow6[windowPicked1].transform.rotation);
        Instantiate(copWindow, windowRow6[windowPicked2].transform.position, windowRow6[windowPicked2].transform.rotation);
        Instantiate(copWindow, windowRow6[windowPicked3].transform.position, windowRow6[windowPicked3].transform.rotation);
        Instantiate(copWindow, windowRow6[windowPicked4].transform.position, windowRow6[windowPicked4].transform.rotation);
        Instantiate(copWindow, windowRow6[windowPicked5].transform.position, windowRow6[windowPicked5].transform.rotation);

        Destroy(windowRow6[windowPicked1]);
        Destroy(windowRow6[windowPicked2]);
        Destroy(windowRow6[windowPicked3]);
        Destroy(windowRow6[windowPicked4]);
        Destroy(windowRow6[windowPicked5]);
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
