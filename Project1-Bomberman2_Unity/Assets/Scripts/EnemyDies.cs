using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDies : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    /*** COLLISION OF ENEMY WITH BOMB ***/
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") )
        {   
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1.5f);
            Debug.Log("Enemy died!");
        }
    }
}
