using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{

    private int rows = 7;
    private int cols = 7;
    private float tileSize = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("GridTile"));

        for(int row = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                float posX = (col * tileSize) - (3 * tileSize);
                float posY = (row * -tileSize) + (3 * tileSize);

                tile.transform.position = new Vector2(posX, posY);
                
            }
        }
        Destroy(referenceTile);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("FirstQuarter", LoadSceneMode.Single);
    }



    class GridTile
    {
        string curColor, correctColor;
        bool constantTile;
        void setColor()
        {
            
        }
    }
}
