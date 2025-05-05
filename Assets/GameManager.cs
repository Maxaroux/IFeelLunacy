using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;

    [SerializeField]
    int correctedPipes = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Debug.Log("You made a correct move!");
        if (correctedPipes == totalPipes)
        {
            Debug.Log("You solved the puzzle!");
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
