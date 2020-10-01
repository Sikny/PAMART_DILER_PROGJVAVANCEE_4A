using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCharacter : MonoBehaviour
{
    private int _score;
    private bool _hasWon;

    private void Update()
    {
        if(_hasWon) return;
        if (_score >= 12)
        {
            _hasWon = true;
            GameManager.Instance.EndGame();
        }
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public bool HasWon
    {
        get => _hasWon;
        set => _hasWon = value;
    }
}
