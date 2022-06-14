using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // Creates a Ray from this object in these directions
    Ray ray_Up;
    Ray ray_Down;
    Ray ray_Left;
    Ray ray_Right;

    // Container for hit data
    RaycastHit hitData;

    private enum Movement  {Up, Down,Left,Right }
    private Movement direction;

    // Update is called once per frame
    void Update()
    {
        CastRays();

        if (direction == Movement.Up)
        {
            MoveUp();
        }
        else if(direction == Movement.Down)
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

    private void CastRays() {
        ray_Up = new Ray(transform.position, (Vector3.up));
        ray_Down = new Ray(transform.position, (Vector3.down));
        ray_Left = new Ray(transform.position, (Vector3.left));
        ray_Right = new Ray(transform.position, (Vector3.right));
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
        transform.Translate(2 * Time.deltaTime * Vector3.left);
        if (Physics.Raycast(ray_Left, out hitData, 1))
        {
            // The Ray hit something!
            if (hitData.collider.tag == "wall")
            {
                AssignRandomMovement();
            }
        }
    }

    private void MoveToRight() {
        transform.Translate(2 * Time.deltaTime * Vector3.right);
        if (Physics.Raycast(ray_Right, out hitData, 1))
        {
            // The Ray hit something!
            if (hitData.collider.tag == "wall")
            {
                AssignRandomMovement();
            }
        }
    }

    private void MoveDown() {
        transform.Translate(2 * Time.deltaTime * Vector3.down);
        if (Physics.Raycast(ray_Down, out hitData, 1))
        {
            // The Ray hit something!
            if (hitData.collider.tag == "wall")
            {
                AssignRandomMovement();
            }
        }
    }

    private void MoveUp() {

        transform.Translate(2 * Time.deltaTime * Vector3.up);
        if (Physics.Raycast(ray_Up, out hitData, 1))
        {
            // The Ray hit something!
            if (hitData.collider.tag == "wall")
            {
                AssignRandomMovement();
            }
        }
    }
}
