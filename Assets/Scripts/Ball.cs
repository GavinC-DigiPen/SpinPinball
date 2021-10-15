//------------------------------------------------------------------------------
//
// File Name:	Ball.cs
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

public class Ball : MonoBehaviour
{
    [Tooltip("Starting velocity of the ball")]
    public float startingVelocity = 8;
    [Tooltip("Max velocity")]
    public float maxVelocity = 10;
    [Tooltip("Button that will reset the ball to 0 0")]
    public KeyCode resetBall = KeyCode.Space;

    private Rigidbody2D ballRB;

    // Start is called before the first frame update
    void Start()
    {
        float rotation = Random.Range(0, 24) * 15;
        transform.Rotate(0, 0, rotation, Space.Self);
        ballRB = GetComponent<Rigidbody2D>();
        ballRB.velocity = transform.up * startingVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(resetBall))
        {
            transform.position = new Vector2(0, 0);
        }

        ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxVelocity);
    }
}
