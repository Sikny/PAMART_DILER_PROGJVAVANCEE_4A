using UnityEngine;

public class Goal : MonoBehaviour {
    public int scoreValue;
    public bool isLeftSide;
    private PlayerScore _playerScore;
    private GameManager _gameManager;
    
    public void Init(PlayerScore playerScore) {
        _playerScore = playerScore;
        _gameManager = GameManager.Instance;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (_gameManager.isServing)
            return;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Frisbee")) {
            
            _playerScore.AddPoint(scoreValue);
            _gameManager.TogglePopUp();
            Frisbee frisbee = other.gameObject.GetComponentInParent<Frisbee>();
            var character = isLeftSide ? _gameManager.lPos : _gameManager.rPos;

            frisbee.offsetToPlayer = character.offsetFrisbee;
            frisbee.SetPlayerPos(character.transform);
            frisbee.SetIsCaught(true);
            character.Frisbee = frisbee;
            character.LockMove();
            _gameManager.isServing = true;

        }

    }
    


}
