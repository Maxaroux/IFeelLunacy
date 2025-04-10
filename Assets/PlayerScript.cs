using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public SpriteRenderer sprite;
    public float slowSpeed, speedScale;
    public float jumpPower, doubleJumpPower;
    public bool playerVisible = true, addedScene = false;
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
            if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && playerVisible)
            {
                if(grounded || doubleJump)
                {
                    rigid2D.linearVelocityY = doubleJump ? doubleJumpPower : jumpPower;
                    doubleJump = !doubleJump;
                }
            }
            if((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && playerVisible && rigid2D.linearVelocityY > 0)
            {
                rigid2D.linearVelocityY *= 0.5f;
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
            grounded = true;
            doubleJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
