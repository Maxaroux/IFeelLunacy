using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MiddleLogicScript : MonoBehaviour
{
    public GameObject Player;
    public bool addedScene;
    public Light2D light2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        light2D = Player.GetComponentInChildren<Light2D>();
        addedScene = false;
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
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(-Player.GetComponent<Rigidbody2D>().position.x-1f, 0));
            GameObject.Find("Lockbox").tag = "Solved";
            SceneManager.UnloadSceneAsync("Earth");
        }
        if(Player.GetComponent<Rigidbody2D>().position.y < -6.5)
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(-6,0);
            Player.GetComponent<Rigidbody2D>().gravityScale = 10;
            Player.tag = "Platformer";
            
            SceneManager.LoadScene("NewMoon", LoadSceneMode.Single);
        }
        if(Player.GetComponent<Rigidbody2D>().position.y > 6.5)
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(-6,0);
            Player.GetComponent<Rigidbody2D>().gravityScale = 10;
            Player.tag = "Platformer";
            light2D.tag = "Night";
            SceneManager.LoadScene("FullMoon", LoadSceneMode.Single);
        }
    }
}
