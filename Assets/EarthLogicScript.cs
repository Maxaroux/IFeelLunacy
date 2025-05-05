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
            SceneManager.LoadScene("FirstQuarter", LoadSceneMode.Single);
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(-Player.GetComponent<Rigidbody2D>().position.x-1f, 0));
        }
        if(Player.GetComponent<Rigidbody2D>().position.x > 10)
        {
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(0, -3));
            Player.tag = "Platformer";
            Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<gameConstants>().platformer;
            light2D.tag = "Day";
            if(Player.GetComponent<Rigidbody2D>().position.y > -7)
                SceneManager.LoadScene("ThirdQuarterSelect", LoadSceneMode.Single);
        }
        if(Player.GetComponent<Rigidbody2D>().position.y < -6.5)
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(-6,0);
            Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<gameConstants>().platformer;
            Player.tag = "Platformer";
            SceneManager.LoadScene("NewMoon", LoadSceneMode.Single);
        }
        if(Player.GetComponent<Rigidbody2D>().position.y > 6.5)
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(-6,0);
            Player.tag = "Platformer";
            Player.GetComponent<SpriteRenderer>().sprite = Player.GetComponent<gameConstants>().platformer;
            SceneManager.LoadScene("FullMoon", LoadSceneMode.Single);
        }
    }
}
