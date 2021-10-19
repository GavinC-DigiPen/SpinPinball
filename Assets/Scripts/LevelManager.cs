//------------------------------------------------------------------------------
//
// File Name:	LevelManager.cs
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
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Score need to change levels")]
    public int scoreNeeded = 10;
    [Tooltip("The name of the scene that should be loaded")]
    public string sceneToLoad;
    [Tooltip("Reset score")]
    public bool resetScore = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnScoreChange.AddListener(CheckLevelChange);
    }

    // Check if the score is high enough to change levels
    private void CheckLevelChange()
    {
        if (GameManager.Score >= scoreNeeded)
        {
            if (resetScore)
            {
                GameManager.Score = 0;
            }
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
