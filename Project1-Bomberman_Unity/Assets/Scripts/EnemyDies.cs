using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDies : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") ) // On Collision with explosion
        {   
            animator.SetBool("Dead", true); // start death animation
            Destroy(gameObject, 1.5f);
            Debug.Log("Enemy died!");
        }
    }
}
