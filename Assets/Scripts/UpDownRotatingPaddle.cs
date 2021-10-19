//------------------------------------------------------------------------------
//
// File Name:	UpDownPaddle.cs
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

public class UpDownRotatingPaddle : MonoBehaviour
{
    [Tooltip("Key to spin right")]
    public KeyCode spinRightKey = KeyCode.D;
    [Tooltip("Key to spin left")]
    public KeyCode spinLeftKey = KeyCode.A;
    [Tooltip("The speed the paddle will rotate")]
    public float rotationSpeed = 5;
    [Tooltip("Key to move up")]
    public KeyCode upKey = KeyCode.W;
    [Tooltip("Key to move down")]
    public KeyCode downKey = KeyCode.S;
    [Tooltip("Up and down speed")]
    public float upDownSpeed = 10;
    [Tooltip("The max and min y for the paddle")]
    public float yMaxMix;

    private int spinDirrection = 0;
    private int upDownDirrection = 0;

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
        if (Input.GetKeyDown(downKey))
        {
            upDownDirrection = -1;
        }
        else if (Input.GetKey(downKey) && !Input.GetKey(upKey))
        {
            upDownDirrection = -1;
        }
        else if (Input.GetKeyDown(upKey))
        {
            upDownDirrection = 1;
        }
        else if (Input.GetKey(upKey) && !Input.GetKey(downKey))
        {
            upDownDirrection = 1;
        }
        else if (!Input.GetKey(downKey) && !Input.GetKey(upKey))
        {
            upDownDirrection = 0;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, upDownDirrection * upDownSpeed);
        if (transform.position.y >= yMaxMix)
        {
            transform.position = new Vector2(transform.position.x, yMaxMix);

        }
        else if (transform.position.y <= -yMaxMix)
        {
            transform.position = new Vector2(transform.position.x, -yMaxMix);
        }

    }
}
