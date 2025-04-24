using UnityEditor;
using UnityEngine;

public class GetDoubleJump : MonoBehaviour
{
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<gameConstants>().hasDoubleJump = true;
        GetComponent<SpriteRenderer>().enabled = false; 
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
