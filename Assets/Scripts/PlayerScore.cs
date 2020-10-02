using TMPro;

public class PlayerScore {
    private int _score;
    private readonly TextMeshProUGUI _txtScore;
    private PlayerScoreCharacter _playerScore;
    
    public PlayerScore(TextMeshProUGUI tmpUi, PlayerScoreCharacter playerScore) {
        _txtScore = tmpUi;
        _playerScore = playerScore;
    }

    public void AddPoint(int value) {
        _score += value;
        _playerScore.Score = _score;
        _txtScore.text = _score.ToString();
      
    }

    public int GetScore() {
        return _playerScore.Score;
    }
}
