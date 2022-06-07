using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 5;
    private float xVel;
    private float yVel;

    /*** ENEMY AI MOVEMENT BACK AND FORTH ***/
    void enemyMoves()
    {
        float rand = Random.Range(0, 4); // 4 conditions at random

        if (rand < 1)
        {
            xVel = 0; // move enemy up
            yVel = speed;
            rb.velocity = new Vector2(xVel, yVel);

        }
        else if (rand < 2 && rand >= 1)
        {
            xVel = speed; // move enemy down
            yVel = 0;
            rb.velocity = new Vector2(xVel, yVel);
        }
        else if (rand < 3 && rand >= 2)
        {
            xVel = -speed; // move enemy left
            yVel = 0;
            rb.velocity = new Vector2(xVel, yVel);
        }
        else
        {
            xVel = 0;
            yVel = -speed; // move enemy right
            rb.velocity = new Vector2(xVel, yVel);
        }   
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        enemyMoves();

    }

    /** ENEMY COLLISION 
    If enemy collides with boulder or player **/
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if(collision.gameObject.CompareTag("Boulder") || collision.gameObject.CompareTag("Player")  ) 
        {   
            xVel= -xVel;
            yVel= -yVel;
            rb.velocity = new Vector2(xVel, yVel); // switch directions
            Debug.Log("Direction changed!");
        }
    }

    void Update()
    {
        /*** Animation variables ***/
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
    }
}
