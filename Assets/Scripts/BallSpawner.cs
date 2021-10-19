//------------------------------------------------------------------------------
//
// File Name:	BallSpawner.cs
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

public class BallSpawner : MonoBehaviour
{
    [Tooltip("The range of delays between balls spawning in")]
    public Vector2 rangeOfSpawnDelays = new Vector2(0.5f, 2f);
    [Tooltip("The ball prefab")]
    public GameObject ball;
    [Tooltip("The maximum number of balls at a time")]
    public int maxBalls = 2;

    private float timeBetweenSpawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBall");
    }

    private IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        Ball[] balls = FindObjectsOfType<Ball>();
        if (balls.Length < maxBalls)
        {
            Instantiate(ball);
        }
        timeBetweenSpawns = Random.Range(rangeOfSpawnDelays.x, rangeOfSpawnDelays.y);
        StartCoroutine("SpawnBall");
    }
}
