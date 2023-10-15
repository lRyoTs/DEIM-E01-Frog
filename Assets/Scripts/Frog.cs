using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int startGridPosition;
    private Vector2Int gridMoveDirection;

    private float gridMoveTimer;
    private float gridMoveTimerMax = 1f;

    private bool hasInput = false; //Check if there is already an input

    void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition;
        gridMoveDirection = new Vector2Int(1, 1);

        transform.eulerAngles = Vector3.zero;
    }

    void Update()
    {
        HandleMoveDirection();
        HandleGridMovement();
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;

        //Check if timer surpassed the max timer
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax; //Reset timer

            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection));

            hasInput = false;
        }


    }
    private void HandleMoveDirection()
    {
        //Pressed E
        if (Input.GetKey(KeyCode.E) && !hasInput)
        {
            if (gridMoveDirection.x != gridMoveDirection.y) // Check if going diagonal down
            {
                //Change direction
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 1;
                hasInput = true;
            }
        }

        //Pressed Q
        if (Input.GetKey(KeyCode.Q) && !hasInput)
        {
            if (gridMoveDirection.x == gridMoveDirection.y) //Check if going diagonal up
            {
                //Change direction
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 1;
                hasInput = true;
            }
        }

        //Pressed D
        if (Input.GetKey(KeyCode.D) && !hasInput)
        {
            if (gridMoveDirection.x == gridMoveDirection.y)
            {
                //Change direction
                gridMoveDirection.x = 1;
                gridMoveDirection.y = -1;
                hasInput = true;
            }

        }

        //Pressed A
        if (Input.GetKey(KeyCode.A) && !hasInput)
        {
            if (gridMoveDirection.x != gridMoveDirection.y)
            {
                //Change direction     
                gridMoveDirection.x = -1;
                gridMoveDirection.y = -1;
                hasInput = true;
            }
        }

    }

    private float GetAngleFromVector(Vector2Int direction)
    {
        float degrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (degrees > 0)
        {
            degrees += 360;
        }

        return degrees - 90;
    }
}
