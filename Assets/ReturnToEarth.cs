using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToEarth : MonoBehaviour
{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().position.x > 10)
        {
            player.GetComponent<Rigidbody2D>().position = new Vector2(0,4.5f);
            SceneManager.LoadScene("Earth");
        }
    }
}
