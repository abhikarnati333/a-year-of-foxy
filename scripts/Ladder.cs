using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    public float speed = 6;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //ClimbingUp
        if (collision.tag == "Player" && Input.GetKey(KeyCode.W))

        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            animator.SetBool("IsClimbing", true);
        }

        //ClimbingDown
        else if (collision.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            animator.SetBool("IsClimbing", true);
        }

        //Idle
        else 
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            animator.SetBool("IsClimbing", false);

        }
        
       
    }
}



