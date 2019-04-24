//Player Movement
/*Dev Note: Anything related to the jump function does not work
//But I would like to build on this project in hopes to get 
create results. Thus I'll keep any jump code in here.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Vector3 defaultPosition; //Grabs the default position the first thing that this object is created
                             //defaultPosition is always set to the starting position because it's not
                             //being updated per frame.

    //Start initializing public variables
    [HideInInspector] public bool right = true;
    [HideInInspector] public bool jump = false;

    public float moveForce;
    public float maxSpeed = 6f;
    public float jumpForce = 1000f;
    public Transform checkCollision;

    [HideInInspector] public bool isWalking = false; //This is used to toggle our boolean for our animator.

    Animator animator;

    private const float moveWithShiftDown = 1f; //Controls movement 1 unit (I hope)
    private bool grounded = false; //To see if the Player is colliding with the ground; This is a part of the jump code.
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        defaultPosition = gameObject.transform.position; //As soon as this GameObject is active, it'll return the position 
                                                         //of the very first frame of the whole game.
        animator = GetComponent<Animator>();                                              
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, checkCollision.position, 1 << LayerMask.NameToLayer("Ground")); //It creates a line for use to detect rather we the player is touching the ground.
        
        //Our animator will always check rather we are walking or not. That'll enable us to use animations.
        animator.SetBool("isWalking", isWalking);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            isWalking = true;

        //Again, this is for jumping, which doens't work.
        if (Input.GetKeyDown(KeyCode.Z) && grounded)
            jump = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //Horizontal is meaning anything that was mapped on the Project Settings
                                               //A and D; Left and Right arrow are currently set
                                               //It'll return values -1 and 1;

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce); //If we are less than the maxSpeed (which is 6), we will had a force
                                                          //To our RigidBody
            
        }



        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); //If we hit/pass the maxnumber
                                                                                                  //It'll remain at the maxspeed
                                                                                                  //by multiplying the sign of 1
                                                                                                  //or -1 to maxSpeed (6 or -6)
          
        }
        //The function Flip() is after the update code
        if (h > 0 && !right)
            Flip();
         else if (h < 0 && right)
            Flip();


        //This is to alter the maxSpeed from 6f to 1f if the Left Shift key is pressed!
        switch (Input.GetKey(KeyCode.LeftShift))
        {
            case true:
                maxSpeed = moveWithShiftDown; break;
                
            case false:
                maxSpeed = 6f; break;
            default: break;
        }

        //This will reset the player position with our initiated default position
        if (Input.GetKey(KeyCode.Space))
            gameObject.transform.position = defaultPosition;

    }

    void Flip()
    {
        right = !right; //This simply inverts the value of right
        Vector3 scale = transform.localScale; //It'll grab the scale of THIS Game Object
        scale.x *= -1; //We'll flip the play over the y-axis
        transform.localScale = scale; //The localScale will then be given the value of scale
    }
}
