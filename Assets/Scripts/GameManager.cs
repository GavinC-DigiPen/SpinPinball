//------------------------------------------------------------------------------
//
// File Name:	GameManager.cs
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
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int score = 0;

    public static UnityEvent OnScoreChange = new UnityEvent();

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }
}
