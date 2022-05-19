using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderCrumble : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // getting the rigidbody
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Explosion") )
        {   
            Destroy(gameObject);
        }
    }
}
