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
        // Player movement on pressing keys 
        if (Input.GetKey(inputUp))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(inputDown))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKey(inputLeft))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(inputRight))
        {
            direction = Vector2.right;      
        }
        else 
        {
            direction = Vector2.zero;
        };

        /* Reference: 
        "TOP DOWN MOVEMENT in Unity!" by Brackeys https://www.youtube.com/watch?v=whzomFgjT50&t=27s
        */
        animator.SetFloat("Horizontal", direction.x); // if this variable changes, player moves along x axis
        animator.SetFloat("Vertical", direction.y); // if this variable changes, player moves along y axis
        animator.SetFloat("Speed", direction.sqrMagnitude); // if this variable is > 0, animations according to the horizontal and vertical variables changes.

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") ) // On collision with Enemy
        {   
            animator.SetBool("Dead", true); // start death animation
            Destroy(gameObject, 1.5f); // remove object
            Debug.Log("Enemy killed you");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") ) // On collision with Explosion
        {   
            animator.SetBool("Dead", true); // start death animation
            Destroy(gameObject, 1.5f);  // remove object
            Debug.Log("Explosion killed you");
        }
    }

    private void FixedUpdate() // Best to use for physics-related functions
    {
        Vector2 position = rb.position; // Vector applied where rigidbody is
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }
}
