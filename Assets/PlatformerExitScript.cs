using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class NewMoonExitScript : MonoBehaviour
{
    public GameObject Player;
    public Light2D light2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        light2D = Player.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.tag = "Top-Down";
        light2D.tag = "Day";
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(SceneManager.GetActiveScene().name.Equals("NewMoon") || SceneManager.GetActiveScene().name.Equals("FullMoon") || SceneManager.GetActiveScene().name.Equals("ThirdQuarterSelect"))
        {
            if(SceneManager.GetActiveScene().name.Equals("NewMoon"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-4.5f);
            else if(SceneManager.GetActiveScene().name.Equals("FullMoon"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,4.5f);
            else if(SceneManager.GetActiveScene().name.Equals("ThirdQuarterSelect"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(9, 0);
            SceneManager.LoadScene("Earth", LoadSceneMode.Single);
        }
        else
        {
            if(SceneManager.GetActiveScene().name.Equals("Pre-DashThirdQuarter"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(8,0);
            else if(SceneManager.GetActiveScene().name.Equals("Post-DashThirdQuarter"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(-8,0);
            SceneManager.LoadScene("ThirdQuarterSelect");
        }
        light2D.tag = "Day";
    }
}
