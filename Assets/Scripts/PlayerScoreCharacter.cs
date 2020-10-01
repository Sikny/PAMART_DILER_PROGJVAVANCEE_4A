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

    public int Result() {
        if (_hasWon) return 1;
        return 0;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
