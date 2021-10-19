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

public class RotatingPaddle : MonoBehaviour
{
    [Tooltip("Key to spin right")]
    public KeyCode spinRightKey = KeyCode.D;
    [Tooltip("Key to spin left")]
    public KeyCode spinLeftKey = KeyCode.A;
    [Tooltip("The speed the paddle will rotate")]
    public float rotationSpeed = 5;
    [Tooltip("Key to circle right")]
    public KeyCode circleRightKey = KeyCode.D;
    [Tooltip("Key to spin left")]
    public KeyCode circleLeftKey = KeyCode.A;
    [Tooltip("The speed the paddle will go around the circle")]
    public Vector2 circleSpeed = new Vector2(5, 5);
    [Tooltip("The radius of the circle the paddle will go around")]
    public Vector2 circleRadius = new Vector2(1, 1);

    private Vector2 startingLocation;
    private int spinDirrection = 0;
    private int circleDirrection = 0;
    private float mathTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        startingLocation = transform.position;
    }

    // Update is called at a fixed rate
    private void FixedUpdate()
    {
        // Get spin dirrection
        if (Input.GetKeyDown(spinLeftKey))
        {
            spinDirrection = -1;
        }
        else if (Input.GetKey(spinLeftKey) && !Input.GetKey(spinRightKey))
        {
            spinDirrection = -1;
        }
        else if (Input.GetKeyDown(spinRightKey))
        {
            spinDirrection = 1;
        }
        else if (Input.GetKey(spinRightKey) && !Input.GetKey(spinLeftKey))
        {
            spinDirrection = 1;
        }
        else if (!Input.GetKey(spinLeftKey) && !Input.GetKey(spinRightKey))
        {
            spinDirrection = 0;
        }

        transform.Rotate(0, 0, -rotationSpeed * spinDirrection, Space.Self);

        // Get up/down dirrection
        if (Input.GetKeyDown(circleLeftKey))
        {
            circleDirrection = -1;
        }
        else if (Input.GetKey(circleLeftKey) && !Input.GetKey(circleRightKey))
        {
            circleDirrection = -1;
        }
        else if (Input.GetKeyDown(circleRightKey))
        {
            circleDirrection = 1;
        }
        else if (Input.GetKey(circleRightKey) && !Input.GetKey(circleLeftKey))
        {
            circleDirrection = 1;
        }
        else if (!Input.GetKey(circleLeftKey) && !Input.GetKey(circleRightKey))
        {
            circleDirrection = 0;
        }

        if (circleDirrection == 1)
        {
            mathTimer += 0.01f;
        }
        else if (circleDirrection == -1)
        {
            mathTimer -= 0.01f;
        }

        transform.position = new Vector2(circleRadius.x * Mathf.Cos(mathTimer * circleSpeed.x) + startingLocation.x, circleRadius.y * Mathf.Sin(mathTimer * circleSpeed.y) + startingLocation.y);
    }
}
