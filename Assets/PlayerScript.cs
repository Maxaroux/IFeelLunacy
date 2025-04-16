using System;
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
    public float jumpPower, doubleJumpPower;
    public bool playerVisible = true;

    public bool hasDoubleJump = false, hasWallJump = false;

    bool doubleJump = false, grounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
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
            if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && playerVisible)
                rigid2D.linearVelocityY = speedScale;
            if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && playerVisible)
                rigid2D.linearVelocityY = -speedScale;
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && playerVisible)
                rigid2D.linearVelocityX = -speedScale;
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && playerVisible)
                rigid2D.linearVelocityX = speedScale;


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
            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && playerVisible)
                rigid2D.linearVelocityX = -speedScale;
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && playerVisible)
                rigid2D.linearVelocityX = speedScale;
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && playerVisible)
            {
                if(grounded || doubleJump)
                {
                    rigid2D.linearVelocityY = (doubleJump && hasDoubleJump) ? doubleJumpPower : jumpPower;
                    if(hasDoubleJump)
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
                    dayCycle.tag = "Night";
                else
                    dayCycle.tag = "Day";
            }

            if(rigid2D.position.x > -3.5f && rigid2D.position.x < 103 && rigid2D.position.y < -3)
                die();
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
            if(!hasWallJump)
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

    public void die()
    {
        if(tag.Equals("Platformer"))
        {
            rigid2D.position = new Vector2(-6, 0);
        }
    }
}
