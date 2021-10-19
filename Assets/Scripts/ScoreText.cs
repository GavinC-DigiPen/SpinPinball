//------------------------------------------------------------------------------
//
// File Name:	ScoreText.cs
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
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI textTMP;

    // Start is called before the first frame update
    void Start()
    {
        textTMP = GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
        GameManager.OnScoreChange.AddListener(UpdateScoreText);
    }

    // Function that updates the text
    void UpdateScoreText()
    {
        textTMP.text = "Score: " + GameManager.Score.ToString();
    }
}
