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
    [Tooltip("The delay before the ball starts moving")]
    public float ballMoveDelay = 0.5f;
    [Tooltip("Button that will reset the ball to 0 0")]
    public KeyCode fixBall = KeyCode.Space;
    [Tooltip("Array of possible colors the ball can be")]
    public Color[] possibleBallColors;
    [Tooltip("A child object that points in the dirrection the ball will move (default points up)")]
    public GameObject velocityPointer;


    private Rigidbody2D ballRB;
    private int colorIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        float rotation = Random.Range(0, 24) * 15;
        transform.Rotate(0, 0, rotation, Space.Self);
        ballRB = GetComponent<Rigidbody2D>();
        Invoke("DelayVelocity", ballMoveDelay);

        colorIndex = Random.Range(0, possibleBallColors.Length);
        GetComponent<SpriteRenderer>().color = possibleBallColors[colorIndex];
        if (velocityPointer)
        {
            velocityPointer.GetComponent<SpriteRenderer>().color = possibleBallColors[colorIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fixBall))
        {
            float rotation = Random.Range(0, 24) * 15;
            transform.Rotate(0, 0, rotation, Space.Self);
            ballRB.velocity = transform.up * startingVelocity;
        }

        ballRB.velocity = Vector3.ClampMagnitude(ballRB.velocity, maxVelocity);
    }

    private void DelayVelocity()
    {
        if (velocityPointer)
        {
            Destroy(velocityPointer);
        }
        ballRB.velocity = transform.up * startingVelocity;
    }

    // Check ball collision with goals
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoalInfo collisionInfo = collision.GetComponent<GoalInfo>();
        if (collisionInfo)
        {
            if (collisionInfo.colorIndex == colorIndex)
            {
                GameManager.Score++;
            }
            else
            {
                GameManager.Score--;
            }

            if (GameManager.Score < 0)
            {
                GameManager.Score = 0;
            }

            Destroy(gameObject);
        }
    }
}
