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

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // getting the rigidbody
    }

    // Update is called once per frame
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
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") )
        {   
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1.5f);
            Debug.Log("Enemy killed you");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") )
        {   
            animator.SetBool("Dead", true);
            Destroy(gameObject, 2f);
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
