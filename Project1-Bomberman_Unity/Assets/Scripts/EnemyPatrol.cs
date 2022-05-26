using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 50; // the actual amount for velocity;
    private float xVel;
    private float yVel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") )
        {   
            animator.SetBool("Dead", true);
            Invoke("DestroyEnemy", 1);
            Debug.Log("Enemy died!");
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
   

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
        if(collision.gameObject.CompareTag("Boulder"))
        {   
            xVel= -xVel;
            yVel= -yVel;
            rb.velocity = new Vector2(xVel, yVel);
            Debug.Log("Direction changed!");
        }
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if(collision.gameObject.CompareTag("Boulder"))
        {
            
            if (yVel == 0)
            {
                float num = Random.Range(0, 3);

                if (num < 1)
                {
                    Debug.Log("0");
                    xVel = -xVel;
                    rb.velocity = new Vector2(xVel, yVel);

                }
                else if (num < 2 && num >= 1)
                {
                    Debug.Log("1");
                    xVel = 0;
                    yVel = speed;
                    rb.velocity = new Vector2(xVel, yVel);
                }
                else if (num < 3 && num >= 2)
                {
                    Debug.Log("2");
                    xVel = 0;
                    yVel = -speed;
                    rb.velocity = new Vector2(xVel, yVel);
                }
            } 
            else if (xVel == 0)
            {
                float num = Random.Range(0, 3);

                if (num < 1)
                {
                    Debug.Log("3");
                    yVel = -yVel;
                    rb.velocity = new Vector2(xVel, yVel);

                }
                else if (num < 2 && num >= 1)
                {
                    Debug.Log("4");
                    xVel = speed;
                    yVel = 0;
                    rb.velocity = new Vector2(xVel, yVel);
                }
                else if (num < 3 && num >= 2)
                {
                    Debug.Log("5");
                    xVel = -speed;
                    yVel = 0;
                    rb.velocity = new Vector2(xVel, yVel);
                }
            }
        }
    }
    */

   

    // Update is called once per frame
    void Update()
    {
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
    }
}
