using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public enum Movement { Up, Down, Left, Right }
    public Movement direction;
    public Animator animator;

    public float speed = 2; // the actual amount for velocity;
    private float xVel;
    private float yVel;

    
   /*** ENEMY MOVES
    The enemy moves at random back and forth on collision with the boulders on the tilemap.
    Also tried to get enemies to change axis as well, but was unable to execute using similar code as written below. 
    Was unable to give this more time, though RayCast would have been the next option
    ***/

   void enemyMoves()
   {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                Debug.Log("Going up");
             //rb.AddForce(new Vector2(0, 50));

                xVel = 0;
                yVel = speed;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 1:

                Debug.Log("Going right");
                //rb.AddForce(new Vector2(50, 0));

                xVel = speed;
                yVel = 0;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 2:

                Debug.Log("Going left");
                //rb.AddForce(new Vector2(-50, 0));

                xVel = -speed;
                yVel = 0;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 3:

                Debug.Log("Going down");
                //rb.AddForce(new Vector2(0, -50));

                xVel = 0;
                yVel = -speed;
                rb.velocity = new Vector2(xVel, yVel);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        enemyMoves();
    }

    private void assignRandomMovement()
    {
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                xVel= -xVel;
                yVel= -yVel;
                rb.velocity = new Vector2(xVel, yVel);
                Debug.Log("Direction changed!");
                break;

            case 1:
                rb.velocity = new Vector2(yVel, xVel);
                break;

            case 2:
                xVel= -xVel;
                yVel= -yVel;
                rb.velocity = new Vector2(yVel, xVel);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if(collision.gameObject.CompareTag("Boulder") || collision.gameObject.CompareTag("Player")  )
        {   
            assignRandomMovement();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
    }
    
   /*** ENEMY MOVES
    The enemy moves at random back and forth on collision with the boulders on the tilemap.
    Also tried to get enemies to change axis as well, but was unable to execute using similar code as written below. 
    Was unable to give this more time, though RayCast would have been the next option
    ***/
    
    /*
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

   
    */
}
