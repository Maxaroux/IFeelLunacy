using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.InputSystem;
using UnityEditor;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.UI;


public class BedLockScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    
    MonoScript playerScript;
    void Start()
    {
        player = GameObject.Find("Player");
        if(player.GetComponent<gameConstants>().hasAnkh)
        {
            GameObject.Find("GetAnkhText").SetActive(false);
            GameObject.Find("Ankh").GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().position.x > 3.25 && player.GetComponent<Rigidbody2D>().position.x < 4.25)
        {
            if(player.GetComponent<Rigidbody2D>().position.y >= 3.3)
            {
                if(Input.GetKeyDown(KeyCode.Space) && player.GetComponent<gameConstants>().hasAnkh)
                {
                    SceneManager.LoadScene("FirstQuarterLockbox", LoadSceneMode.Single);
                    player.tag = "InPuzzle";
                }
            }
        }
        if(player.GetComponent<Rigidbody2D>().position.x >= -4 && player.GetComponent<Rigidbody2D>().position.x <= -1.3)
        {
            Debug.Log("rightX");
            if(player.GetComponent<Rigidbody2D>().position.y >= 1.5)
            {
                Debug.Log("rightY");
                if(player.GetComponent<gameConstants>().hasAnkh == false && Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("gettingAnkh?");
                    player.GetComponent<gameConstants>().hasAnkh = true;
                    GameObject.Find("Ankh").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("GetAnkhText").SetActive(false);
                }
            }
        }
        
        if(player.GetComponent<gameConstants>().FirstQuarterLock)
            tag = "Solved";
    }
}
