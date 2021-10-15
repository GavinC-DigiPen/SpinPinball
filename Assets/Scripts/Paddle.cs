//------------------------------------------------------------------------------
//
// File Name:	Paddle.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    SpinPinball
// Course:	    WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Tooltip("Key to spin right")]
    public KeyCode spinRightKey = KeyCode.D;
    [Tooltip("Key to spin left")]
    public KeyCode spinLeftKey = KeyCode.A;
    [Tooltip("The speed the paddle will rotate")]
    public float rotationSpeed = 5;
    [Tooltip("The speed the paddle will go around the circle")]
    public Vector2 circleSpeed = new Vector2(5, 5);
    [Tooltip("The radius of the circle the paddle will go around")]
    public Vector2 circleRadius = new Vector2(1, 1);

    private Vector2 startingLocation;
    private int dirrection = 0;
    private float mathTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingLocation = transform.position;
    }

    // Update is called at a fixed rate
    private void FixedUpdate()
    {
        // Get dirrection
        if (Input.GetKeyDown(spinLeftKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKey(spinLeftKey) && !Input.GetKey(spinRightKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKeyDown(spinRightKey))
        {
            dirrection = 1;
        }
        else if (Input.GetKey(spinRightKey) && !Input.GetKey(spinLeftKey))
        {
            dirrection = 1;
        }
        else if (!Input.GetKey(spinLeftKey) && !Input.GetKey(spinRightKey))
        {
            dirrection = 0;
        }

        // Movement 
        transform.Rotate(0, 0, -rotationSpeed * dirrection, Space.Self);

        if (dirrection == 1)
        {
            mathTimer += 0.01f;
        }
        else if (dirrection == -1)
        {
            mathTimer -= 0.01f;
        }
        transform.position = new Vector2(circleRadius.x * Mathf.Cos(mathTimer * circleSpeed.x) + startingLocation.x, circleRadius.y * Mathf.Sin(mathTimer * circleSpeed.y) + startingLocation.y);
    }
}
