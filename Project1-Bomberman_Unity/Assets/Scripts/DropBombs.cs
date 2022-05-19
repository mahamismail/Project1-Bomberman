using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBombs : MonoBehaviour
{
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Space;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;

    public GameObject explosionPrefab; // This makes sure the prefab chosen has the explosion script on it
    public float explosionDuration = 3f;
    public int explosionRadius = 1;

    public LayerMask explosionLayerMask;

    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            StartCoroutine(DropBomb());
        }
    }

    private IEnumerator DropBomb()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);


        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

        //Physics.IgnoreCollision(bomb.GetComponent<Collider>(), gameObject.CompareTag("Player").GetComponent<Collider>(), true );
        yield return new WaitForSeconds(bombFuseTime);
        Destroy(bomb);

        /* When bomb is triggered, instantiate the explosion
        & make first child of the explosion ACTIVE */

        //transform.GetChild(0).explosionPrefab.setActive(true);
        GameObject explosion = Instantiate(explosionPrefab,position, Quaternion.identity);
        Destroy(explosion.gameObject, explosionDuration);      

        /*
        Explode(position,Vector2.up, explosionRadius);
        Explode(position,Vector2.down, explosionRadius);
        Explode(position,Vector2.left, explosionRadius);
        Explode(position,Vector2.right, explosionRadius);
        */   
    }


    /*

    /* This function instantiates explosions around the bomb, extending vertically
    and horizontally from the middle of the explosion
    *\

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0) {
            return;
        }

        position += direction;

        if(Physics2D.OverlapBox(position, Vector2.one, 0f, explosionLayerMask)

        GameObject explosion = Instantiate(explosionPrefab,position, Quaternion.identity);
        
        if (length > 1){
            // set the second child of explosion ACTIVE
        }
        else 
        {
            // set the third/last child of explosion ACTIVE

        }

        Destroy(explosion.gameObject, explosionDuration);
    }
    */
}
