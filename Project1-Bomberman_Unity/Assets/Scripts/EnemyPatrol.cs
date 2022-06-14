using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 5; // the actual amount for velocity;
 
    //Creates a Ray from this object in these directions
    Ray2D ray_Up;
    Ray2D ray_Down;
    Ray2D ray_Left;
    Ray2D ray_Right;

    //Container for hit data
    RaycastHit2D hitData;

    private enum Movement {Up, Down, Left, Right}
    private Movement direction;

     // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AssignRandomMovement();
    }

    void Update()
    {
        CastRays();

        if (direction == Movement.Up)
        {
            Debug.Log("Going up");
            MoveUp();
        }
        else if(direction == Movement.Down)
        {
            Debug.Log("Going down");
            MoveDown();
        }
        else if (direction == Movement.Right)
        {
            Debug.Log("Going right");
            MoveRight();
        }
        else if (direction == Movement.Left)
        {
            Debug.Log("Going left");
            MoveLeft();
        };

        //animator.SetFloat("Horizontal", rb.velocity.x);
        //animator.SetFloat("Vertical", rb.velocity.y);
        //animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    private void CastRays() 
    {
        ray_Up = new Ray2D(transform.position, (Vector2.up));
        ray_Down = new Ray2D(transform.position, (Vector2.down));
        ray_Left = new Ray2D(transform.position, (Vector2.left)); 
        ray_Right = new Ray2D(transform.position, (Vector2.right));
    }

    // Assigns Random Movement to the ENEMY
    private void AssignRandomMovement()
    {
        int rand = Random.Range(0,4);
        switch(rand)
        {
            case 0:
                direction = Movement.Up;
                break;

            case 1:
                direction = Movement.Down;
                break;

            case 2:
                direction = Movement.Right;
                break;

            case 3:
                direction = Movement.Left;
                break;
        }
    }

    private void MoveLeft() 
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
        
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, Vector2.left, 1);
            
        // The Ray hit something!
        if (hitData.collider.tag == "Boulder" || hitData.collider.tag == "Player" )
        {
            Debug.Log("Assigning random movement");
            AssignRandomMovement();
        }
    }

    private void MoveRight() 
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
        
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, Vector2.right, 1);
            
        // The Ray hit something!
        if (hitData.collider.tag == "Boulder" || hitData.collider.tag == "Player" )
        {
            Debug.Log("Assigning random movement");
            AssignRandomMovement();
        }
    }

    private void MoveUp() 
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, Vector2.up, 1);
            
        // The Ray hit something!
        if (hitData.collider.tag == "Boulder" || hitData.collider.tag == "Player" )
        {
            Debug.Log("Assigning random movement");
            AssignRandomMovement();
        }
    }

    private void MoveDown() 
    {
        
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, Vector2.down, 1);
            
        // The Ray hit something!
        if (hitData.collider.tag == "Boulder" || hitData.collider.tag == "Player" )
        {
            Debug.Log("Assigning random movement");
            AssignRandomMovement();
        }
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
