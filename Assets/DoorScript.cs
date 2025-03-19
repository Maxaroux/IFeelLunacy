using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject topWall, bottomWall, lockbox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lockbox.tag != "Unsolved")
        {
            Physics2D.IgnoreCollision(topWall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bottomWall.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
