using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
Help taken from: "How to make Bomberman in Unity (Complete Tutorial) 💣💥" by Zigurous.
www.youtube.com/watch?v=8agb6x5RpOI
*/

public class DropBombs : MonoBehaviour
{
    //Input Variables
    public KeyCode inputKey = KeyCode.Space;

    //Bomb Variables
    public GameObject bombPrefab;
    public float bombFuseTime = 3f;

    //Explosion Variables
    public GameObject explosionPrefab;
    public float explosionDuration = 1f;
    public LayerMask explosionLayerMask;
    public GameObject destructiblePrefab;
    public Tilemap destructibleTiles;


    private void Update()
    {
        if (Input.GetKeyDown(inputKey)) // On key down, execute DropBomb method
        {
            StartCoroutine(DropBomb());
        }
    }

    /*** DROP BOMBS 
    This method instantiates a bomb in the position of the player object. After allocated bombFuseTime, 
    explosion is instantiated in place of the bomb, and Explode methods are called to place more explosions 
    horizontally and vertically 1 tile in each direction.

    This method constantly updates the position of bomb.
    **/

    private IEnumerator DropBomb()
    {
        
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x); // updating position
        position.y = Mathf.Round(position.y);

        /* When bomb is triggered, instantiate the explosion*/
       GameObject explosion = Instantiate(explosionPrefab,position, Quaternion.identity);
       Destroy(explosion.gameObject, explosionDuration);

        Explode(position + new Vector2Int(1,0), Quaternion.identity);
        Explode(position + new Vector2Int(-1,0), Quaternion.identity);
        Explode(position + new Vector2Int(0,1), Quaternion.identity);
        Explode(position + new Vector2Int(0,-1), Quaternion.identity);

        
        Destroy(bomb.gameObject);
        
    }

    /*** EXPLODE
    This function instantiates explosions around the bomb, extending vertically
    and horizontally from the middle of the explosion ***/

    private void Explode(Vector2 position, Quaternion direction)
    {
        
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask)) 
        {
            // If the instantiated explosion overlaps a destructible tile from the tilemap, then remove the destructible tile
            ClearDestructible(position);
            return;
        }
        
        // 
        GameObject explosion = Instantiate(explosionPrefab,position, direction);
        Destroy(explosion.gameObject, explosionDuration);
            
    }

    /*** CLEAR destructible
    This function removes a colliding tile from the tilemap
    ***/
    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null) // if tile is present
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity); // then instantiate the destructible prefab in the same position 
            destructibleTiles.SetTile(cell, null);
        }
    }

    /*** After instantiating the bomb, the player can move out of the position, 
    but upon leaving, the bombs colliders are set to not trigger so the player can not walk over the bomb again. ***/  
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb")) { 
            other.isTrigger = false;
        }
    }
}
