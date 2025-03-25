using System.ComponentModel;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class BedroomLogicScript : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D PlayerBody;
    bool addedScene = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerBody = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Rigidbody2D>().position.x > 9.5)
        {
            if(!addedScene)
            {
                SceneManager.LoadScene("Earth", LoadSceneMode.Additive);
                addedScene = true;
            }
            Scene currentScene = SceneManager.GetSceneByName("Earth");
            PlayerBody.MovePosition(new Vector2(-PlayerBody.position.x + 1f, 0));
            SceneManager.UnloadSceneAsync("FirstQuarter");
        }
    }
}
