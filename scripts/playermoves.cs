using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playermoves : MonoBehaviour
{

    //Start

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    
   
    //FSM
    private enum State { idle, running, jumping,climb}
    private State state = State.idle;
    private float hangCounter;

    //Inspector
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherryText;
    [SerializeField] private float hurtforce = 10f;
    [SerializeField] private AudioSource cherry;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private bool grounded;
    [SerializeField] private float hangTime = .2f;



    //Variables
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        
    }
        


    
    
   

    //Main Movement
    private void Update()

    {
        float hdirection = Input.GetAxis("Horizontal");


        //moving left
        if (hdirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            
        }



        //moving right

        else if (hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            
        }


        //jumping

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            state = State.jumping;
        }


        
        VelocityState();
        anim.SetInteger("state", (int)state);

        if (grounded)
        {
            hangCounter = hangTime;

        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.jumping;
        }

    }
        




    //GroundCheck

    private void FixedUpdate()

    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
    }


    //Cherries

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.tag == "collectables")
        {
            cherry.Play();
            Destroy(collision.gameObject);
            cherries += 1;
            cherryText.text = cherries.ToString();
        }
    }

    //Enemy (ignore for now)

    private void OnCollisionEnter2D(Collision2D other)

    {
        if(other.gameObject.tag == "Enemy")

        {
            //if(state == State.falling)
            {
                Destroy(other.gameObject);
            }
            //else
            {
                if(other.gameObject.transform.position.x > transform.position.x)
                {

                }

                else
                {

                }
            }
        }
    }

   

    //More Movement

    private void VelocityState()

    {
         if (state == State.jumping)
        {
            if(rb.velocity.y < .1f && grounded)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }

        else
        {
            state = State.idle;
        }

    }
}
   


  



    

  




    

            
       





       







   

   









