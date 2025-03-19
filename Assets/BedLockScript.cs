using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.InputSystem;

public class BedLockScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().position.x > 3.25 && player.GetComponent<Rigidbody2D>().position.x < 4.25)
        {
            if(player.GetComponent<Rigidbody2D>().position.y >= 3.3)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("BedroomLockbox", LoadSceneMode.Single);
            }
        }


        if(Input.GetKeyDown(KeyCode.P))
            tag = "Solved";
    }
}
