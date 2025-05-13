using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;

    [SerializeField]
    int correctedPipes = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        Player.tag = "inPuzzle";

        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes++;
        if (correctedPipes == totalPipes)
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(3.8f, 3.6f);
            Player.GetComponent<gameConstants>().FirstQuarterLock = true;
            Player.tag = "Top-Down";
            SceneManager.LoadScene("FirstQuarter", LoadSceneMode.Single);
        }
    }
    public void wrongMove()
    {
        correctedPipes--;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
