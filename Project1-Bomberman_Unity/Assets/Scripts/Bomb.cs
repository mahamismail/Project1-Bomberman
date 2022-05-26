using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") )
        {   
            GetComponent<Collider>().isTrigger = true;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
