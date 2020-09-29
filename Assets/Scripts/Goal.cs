using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour {
    public int scoreValue;
    private PlayerScore _playerScore;

    public void Init(PlayerScore playerScore) {
        _playerScore = playerScore;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Frisbee")) {
            _playerScore.AddPoint(scoreValue);
        }
    }
}
