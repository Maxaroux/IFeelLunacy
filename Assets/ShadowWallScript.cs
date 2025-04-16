using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowWallScript : MonoBehaviour
{
    public GameObject Player;
    public Light2D ligt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        ligt = Player.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ligt.tag.Equals("Night"))
            GetComponent<BoxCollider2D>().enabled = false;
        else
            GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ligt.tag.Equals("Day"))
            Player.GetComponent<PlayerScript>().die();
    }
}
