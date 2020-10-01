using TMPro;

public class PlayerScore {
    private int _score;
    private readonly TextMeshProUGUI _txtScore;

    public PlayerScore(TextMeshProUGUI tmpUi) {
        _txtScore = tmpUi;
    }

    public void AddPoint(int value) {
        _score += value;
        _txtScore.text = _score.ToString();
        if (_score >= 12)
        {
            GameManager.Instance.soundManager.StopPlayingAllMusics();
            GameManager.Instance.soundManager.Play("FinishTheme");
            GameManager.Instance.EndGame();
        }
    }
}
