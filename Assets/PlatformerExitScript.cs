using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMoonExitScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.tag = "Top-Down";
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(SceneManager.GetActiveScene().name.Equals("NewMoon"))
            Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-4.5f);
        else if(SceneManager.GetActiveScene().name.Equals("FullMoon"))
            Player.GetComponent<Rigidbody2D>().position = new Vector2(0,4.5f);
        SceneManager.LoadScene("Earth", LoadSceneMode.Single);
    }
}
