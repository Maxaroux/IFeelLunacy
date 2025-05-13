using System;
using System.Linq;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public SpriteRenderer sprite;
    public Light2D dayCycle;
    public float slowSpeed, speedScale;
    public bool playerVisible = true;

    //variables to make double jump work when unlocked
    bool doubleJump = false, grounded;
    public float jumpPower, doubleJumpPower;

    
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        if(SceneManager.GetSceneByName("TitleScreen").Equals(SceneManager.GetActiveScene()))
        {
            playerVisible = false;
            sprite.enabled = false;
        }
        else
        {
            playerVisible = true;
            sprite.enabled = true;
        }

        if(tag.Equals("Top-Down"))
        {    
            sprite.sprite = GetComponent<gameConstants>().topDown;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && playerVisible)
            {
                rigid2D.linearVelocityY = speedScale;
                transform.eulerAngles = Vector3.forward;
            }
            if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && playerVisible)
            {
                rigid2D.linearVelocityY = -speedScale;
                transform.eulerAngles = Vector3.forward * 180;
            }
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && playerVisible)
            {
                rigid2D.linearVelocityX = -speedScale;
                transform.eulerAngles = Vector3.forward * 90;
            }
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && playerVisible)
            {
                rigid2D.linearVelocityX = speedScale;
                transform.eulerAngles = Vector3.back * 90;
            }

            if(rigid2D.totalForce.y == 0)
            {
                //y velocity
                if(rigid2D.linearVelocityY > 0)
                    rigid2D.linearVelocityY-=slowSpeed;
                if(rigid2D.linearVelocityY < 0)
                    rigid2D.linearVelocityY+=slowSpeed;
                if(rigid2D.linearVelocityY < 1 && rigid2D.linearVelocityY > -1)
                    rigid2D.linearVelocityY = 0;
            }
        }
        else if(tag.Equals("Platformer"))
        {
            transform.eulerAngles = Vector3.forward;
            GetComponent<Rigidbody2D>().gravityScale = 10;
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && playerVisible)
                rigid2D.linearVelocityX = -speedScale;
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && playerVisible)
                rigid2D.linearVelocityX = speedScale;
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && playerVisible)
            {
                if(grounded || doubleJump)
                {
                    rigid2D.linearVelocityY = (doubleJump && GetComponent<gameConstants>().hasDoubleJump) ? doubleJumpPower : jumpPower;
                    if(GetComponent<gameConstants>().hasDoubleJump)
                        doubleJump = !doubleJump;
                }
            }
            if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) && playerVisible && rigid2D.linearVelocityY > 0)
            {
                rigid2D.linearVelocityY *= 0.5f;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                if(dayCycle.tag.Equals("Day"))
                    GetComponent<gameConstants>().isDay = false;
                else
                    GetComponent<gameConstants>().isDay = true;
            }

            if(GetComponent<gameConstants>().isDay)
                dayCycle.tag = "Day";
            else
                dayCycle.tag = "Night";

            if(!SceneManager.GetActiveScene().name.Equals("ThirdQuarterSelect"))
            {
                if(rigid2D.position.x > -3.5f && rigid2D.position.x < 103 && rigid2D.position.y < -3)
                    die();
            }

            if(SceneManager.GetActiveScene().name.Equals("ThirdQuarterSelect") && Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("why");
                tag = "Top-Down";
                GetComponentInChildren<Light2D>().tag = "Day";
                GetComponent<Rigidbody2D>().position = new Vector2(9, 0);
                SceneManager.LoadScene("Earth", LoadSceneMode.Single);
            }


        }

        if(rigid2D.totalForce.x == 0)
        {
            if(rigid2D.linearVelocityX > 0)
                rigid2D.linearVelocityX-=slowSpeed;
            if(rigid2D.linearVelocityX < 0)
                rigid2D.linearVelocityX+=slowSpeed;
            if(rigid2D.linearVelocityX < 1 && rigid2D.linearVelocityX > -1)
                rigid2D.linearVelocityX = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag.Equals("Platformer"))
        {
            if(!GetComponent<gameConstants>().hasWallJump)
            {
                foreach (ContactPoint2D hitPos in collision.contacts)
                {
                    if (hitPos.normal.x != 0) // check if the wall collided on the sides
                        grounded = false; // boolean to prevent player from being able to jump
                    else if (hitPos.normal.y > 0) // check if its collided on top 
                    {
                        grounded = true;
                        doubleJump = false;
                    }
                    else grounded = false;
                }
            }
            else
            {
                grounded = true;
                doubleJump = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

<<<<<<< Updated upstream
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name.Equals("ExitCollider") && Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("left");
            tag = "Top-Down";
            rigid2D.position = new Vector2(9,0);
            GetComponent<gameConstants>().isDay = true;
            SceneManager.LoadScene("Earth", LoadSceneMode.Single);
        }
    }

=======
>>>>>>> Stashed changes
    public void die()
    {
        if(tag.Equals("Platformer"))
        {
            rigid2D.position = new Vector2(-6, 0);
            rigid2D.linearVelocityY = 0;
        }
    }
}
