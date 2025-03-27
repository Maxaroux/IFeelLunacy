using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleLogicScript : MonoBehaviour
{
    public GameObject Player;
    public bool addedScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Rigidbody2D>().position.x < -10)
        {
            if(!addedScene)
            {
                SceneManager.LoadScene("FirstQuarter", LoadSceneMode.Additive);
                addedScene = true;
            }
            Scene currentScene = SceneManager.GetSceneByName("FirstQuarter");
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(-Player.GetComponent<Rigidbody2D>().position.x-1f, 0));
            GameObject.Find("Lockbox").tag = "Solved";
            SceneManager.UnloadSceneAsync("Earth");
        }
        else if(Player.GetComponent<Rigidbody2D>().position.y < -6.5)
        {
            if(!addedScene)
            {
                SceneManager.LoadScene("NewMoon", LoadSceneMode.Additive);
                addedScene = true;
            }
            Scene currentScene = SceneManager.GetSceneByName("NewMoon");
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0,0));
            SceneManager.UnloadSceneAsync("Earth");
        }
        addedScene = false;
    }
}
