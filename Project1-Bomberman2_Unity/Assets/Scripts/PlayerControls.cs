using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 5f;

    // Public variables for Input Keys to move Player
    public KeyCode inputUp = KeyCode.UpArrow;
    public KeyCode inputDown = KeyCode.DownArrow;
    public KeyCode inputLeft = KeyCode.LeftArrow;
    public KeyCode inputRight = KeyCode.RightArrow;
    public KeyCode restartGame = KeyCode.R;

    private Vector2 direction = Vector2.down; // default direction of the player. (front facing)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // getting the rigidbody
    }

    void Update()
    {
        /*** PLAYER MOVEMENT ACCORDING TO INPUT ***/

        if (Input.GetKey(inputUp)) // if Player goes up add Vector2(0, 1)
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(inputDown)) // if Player goes up add Vector2(0, -1)
        {
            direction = Vector2.down;
        }
        else if (Input.GetKey(inputLeft))
        {
            direction = Vector2.left; // if Player goes up add Vector2(-1, 0)
        }
        else if (Input.GetKey(inputRight))
        {
            direction = Vector2.right; // if Player goes up add Vector2(1, 0)      
        }
        else 
        {
            direction = Vector2.zero; // Don't do anything
        };

        /*** PLAYER MOVEMENT ANIMATIONS

        Reference: 
        Add animations using keyframes and Animator
        "TOP DOWN MOVEMENT in Unity!" by Brackeys https://www.youtube.com/watch?v=whzomFgjT50&t=27s
        ***/

        animator.SetFloat("Horizontal", direction.x); // Linking Horizontal parameter from animator to direction of player 
        animator.SetFloat("Vertical", direction.y); // Linking Vertical parameter from animator to direction of player

        /* Linking speed parameter from animator to script. If speed is more than 0.01, animations will be initiated, 
        depending on horizontal and vertical parameters*/
        animator.SetFloat("Speed", direction.sqrMagnitude); 

    }

    /*** COLLISION WITH ENEMY ***/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") ) // If Player collides with the Enemy
        {   
            animator.SetBool("Dead", true); // Initiate death animation, through animator's Dead variable
            Destroy(gameObject, 1.5f); // Destroy after 1.5f time
            Debug.Log("Enemy killed you");
        }
    }

    /*** COLLISION WITH EXPLOSION ***/

    private void OnTriggerEnter2D(Collider2D col) // If Player collides with the Explosion
    {
        if(col.gameObject.CompareTag("Explosion") )
        {   
            animator.SetBool("Dead", true); // Initiate death animation, through animator's Dead variable
            Destroy(gameObject, 2f);
            Debug.Log("Explosion killed you");
        }
    }

    /*** FOR SMOOTH TRANSITION MOVEMENT OF PLAYER ***/

    private void FixedUpdate() // Best to use for physics-related functions
    {
        Vector2 position = rb.position; // Keep position of rigidbody updated
        Vector2 translation = direction * speed * Time.fixedDeltaTime; 

        rb.MovePosition(position + translation);
    }
}
