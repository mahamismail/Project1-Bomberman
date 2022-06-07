using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 5; // the actual amount for velocity;
    private float xVel;
    private float yVel;

    
   /*** ENEMY MOVES
    The enemy moves at random back and forth on collision with the boulders on the tilemap.
    Also tried to get enemies to change axis as well, but was unable to execute using similar code as written below. 
    Was unable to give this more time, though RayCast would have been the next option
    ***/
    void enemyMoves()
    {
        float rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Debug.Log("Going up");
            //rb.AddForce(new Vector2(0, 50));

            xVel = 0;
            yVel = speed;
            rb.velocity = new Vector2(xVel, yVel);

        }
        else if (rand < 2 && rand >= 1)
        {
            Debug.Log("Going right");
            //rb.AddForce(new Vector2(50, 0));

            xVel = speed;
            yVel = 0;
            rb.velocity = new Vector2(xVel, yVel);
        }
        else if (rand < 3 && rand >= 2)
        {
            Debug.Log("Going left");
            //rb.AddForce(new Vector2(-50, 0));

            xVel = -speed;
            yVel = 0;
            rb.velocity = new Vector2(xVel, yVel);
        }
        else
        {
            Debug.Log("Going down");
            //rb.AddForce(new Vector2(0, -50));

            xVel = 0;
            yVel = -speed;
            rb.velocity = new Vector2(xVel, yVel);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        enemyMoves();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if(collision.gameObject.CompareTag("Boulder") || collision.gameObject.CompareTag("Player")  )
        {   
            xVel= -xVel;
            yVel= -yVel;
            rb.velocity = new Vector2(xVel, yVel);
            Debug.Log("Direction changed!");
        }
    }

    // Update is called once per frame
    void Update()
    {
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
    }
}
