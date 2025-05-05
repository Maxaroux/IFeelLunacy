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
        if(SceneManager.GetActiveScene().name.Equals("NewMoon") || SceneManager.GetActiveScene().name.Equals("FullMoon") || SceneManager.GetActiveScene().name.Equals("ThirdQuarterSelect"))
        {
            if(SceneManager.GetActiveScene().name.Equals("NewMoon"))
            {
                Player.tag = "Top-Down";
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-4.5f);
                SceneManager.LoadScene("Earth", LoadSceneMode.Single);
            }
            else if(SceneManager.GetActiveScene().name.Equals("FullMoon"))
            {
                Player.tag = "Top-Down";
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,4.5f);
                SceneManager.LoadScene("Earth", LoadSceneMode.Single);
            }
        }
        else
        {
            Player.tag = "Platformer";
            if(SceneManager.GetActiveScene().name.Equals("PreDashThirdQuarter"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-3);
            else if(SceneManager.GetActiveScene().name.Equals("PostDashThirdQuarter"))
                Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-3);
            SceneManager.LoadScene("ThirdQuarterSelect");
        }
        light2D.tag = "Day";
    }
}
