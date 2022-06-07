using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Tilemaps;

public class DropBombs : MonoBehaviour
{
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Space; // Drop bombs
    public float bombFuseTime = 3f;

    public GameObject explosionPrefab;
    public float explosionDuration = 1f;
    public LayerMask explosionLayerMask;

    /** getting Destructible prefabs and using Tilemaps ***/

    public GameObject destructiblePrefab;
    public Tilemap destructibleTiles;


    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            StartCoroutine(DropBomb()); // StartCoroutine helps spead text across several scenes
        }
    }

    private IEnumerator DropBomb()
    {
        
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity); // create bomb and drop it in the position

        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        /* When bomb is triggered, instantiate the explosion
        & make first child of the explosion ACTIVE */
        
       GameObject explosion = Instantiate(explosionPrefab,position, Quaternion.identity);
       Destroy(explosion.gameObject, explosionDuration);

        Explode(position + new Vector2Int(1,0), Quaternion.identity);
        Explode(position + new Vector2Int(-1,0), Quaternion.identity);
        Explode(position + new Vector2Int(0,1), Quaternion.identity);
        Explode(position + new Vector2Int(0,-1), Quaternion.identity);

        
        Destroy(bomb.gameObject);
        
    }

    /*This function instantiates explosions around the bomb, extending vertically
    and horizontally from the middle of the explosion */

    private void Explode(Vector2 position, Quaternion direction)
    {
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            Debug.Log("Boulder hit");
            ClearDestructible(position);
            return;
        }
            
            GameObject explosion = Instantiate(explosionPrefab,position, direction);
            Destroy(explosion.gameObject, explosionDuration);
            
    }

    /** REMOVE DESTRUCTIBLE TILE IF BOMB TOUCHES IT ***/

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
        }
    }

    /** PLAYER CAN WALK OFF THE BOMB AND CANT WALK ACROSS AFTER ***/
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb")) {
            other.isTrigger = false;
        }
    }
}
