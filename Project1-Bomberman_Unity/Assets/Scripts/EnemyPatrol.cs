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
    The enemy can randomly move in any of the 4 directions.
    ***/
   void enemyMoves()
   {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                Debug.Log("Going up");

                xVel = 0;
                yVel = speed;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 1:

                Debug.Log("Going right");

                xVel = speed;
                yVel = 0;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 2:

                Debug.Log("Going left");

                xVel = -speed;
                yVel = 0;
                rb.velocity = new Vector2(xVel, yVel);
                break;

            case 3:

                Debug.Log("Going down");

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


    /*** ASSIGN RANDOM MOVEMENT
    This allows the enemy to switch its direction.


    ISSUES: Enemies successfully switch directions upon collision when this is called, but the objects halts at a certain point, 
    unable to understand why. Was unable to give much time to this particular problem.
    ***/
    private void assignRandomMovement()
    {
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0: // switch to opposite direction
                xVel= -xVel;
                yVel= -yVel;
                rb.velocity = new Vector2(xVel, yVel);
                Debug.Log("Direction changed!");
                break;

            case 1: // switch to perpendicular direction
                rb.velocity = new Vector2(yVel, xVel);
                break;

            case 2: // switch to opposite perpendicular direction
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
    
}
