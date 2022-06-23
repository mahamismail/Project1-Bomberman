using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public enum Movement { Up, Down, Left, Right }
    public Movement direction;

    // Update is called once per frame
    void Update() {

        if (direction == Movement.Up)
        {
            MoveUp();
        }
        else if (direction == Movement.Down)
        {

            MoveDown();
        }
        else if (direction == Movement.Right)
        {
            MoveToRight();
        }
        else
        {
            MoveToLeft();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("wall"))
        {
            AssignRandomMovement();     
        }
    }


    //Assigns Random Movement to the Enemy
    private void AssignRandomMovement() {

        int rand = Random.Range(0, 4);
        
        switch (rand)
        {
            case 0:
                direction = Movement.Up;
                break;

            case 1:
                direction = Movement.Down;
                break;

            case 2:
                direction = Movement.Right;
                break;

            case 3:
                direction = Movement.Left;
                break;

        }
    }

    private void MoveToLeft() {

        transform.Translate(2 * Time.deltaTime * Vector2.left);

    }

    private void MoveToRight() {

        transform.Translate(2 * Time.deltaTime * Vector2.right);

    }

    private void MoveDown() {
        transform.Translate(2 * Time.deltaTime * Vector2.down);
    }

    private void MoveUp() {

        transform.Translate(2 * Time.deltaTime * Vector2.up);

    }
}
