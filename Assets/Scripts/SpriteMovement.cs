//Player controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{

	public float speed;
	public float height;
    public float climb;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJump;
    public bool ladder;
    private float climbVelocity;
    private float gravityStore;
    private Rigidbody2D myrig2D;

    public Animator animation;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        myrig2D = GetComponent<Rigidbody2D>();
        gravityStore = myrig2D.gravityScale;
    }

    void FixedUpdate(){
    	grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
    }

    void Update()
    {
        animation.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        animation.SetBool("Player_walk", false);
        animation.SetBool("Player_idle", true);
        animation.SetBool("Player_climb", false);
        animation.SetBool("Player_jump", false);

    	if(grounded){
    		doubleJump = false;
    	}

        if(Input.GetKeyDown(KeyCode.Space) && grounded){ //jump
        	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, height);
            animation.SetBool("Player_jump", true);
        }
        if(Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump){ //double jump
        	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, height);
        	doubleJump = true;
            animation.SetBool("Player_jump", true);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){ //move right
        	GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            walkAnimation();
            if(spriteRenderer != null){
                spriteRenderer.flipX = false;
            }
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){ //move left
        	GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            walkAnimation();
            if(spriteRenderer != null){
                spriteRenderer.flipX = true;
            }
        }
        if(!ladder){
            myrig2D.gravityScale = 1.5f;
            animation.SetBool("Player_climb", false);
        }
        if(ladder){

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){ //Climb
                myrig2D.gravityScale = 0.75f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, climb);
                animation.SetBool("Player_idle", false);
                animation.SetBool("Player_climb", true); 
            }
            
        }
            
    }

    void walkAnimation(){
        animation.SetBool("Player_idle", false);
        animation.SetBool("Player_walk", true);
    }

}
