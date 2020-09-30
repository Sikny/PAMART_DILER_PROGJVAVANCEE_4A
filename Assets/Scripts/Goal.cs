using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour {
    public int scoreValue;
    public Stadium stadium;
    public bool isLeftSide;
    private PlayerScore _playerScore;
    
    public void Init(PlayerScore playerScore) {
        _playerScore = playerScore;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        //if (stadium.isServing)
         //   return;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Frisbee")) {
            
            _playerScore.AddPoint(scoreValue);
            Frisbee frisbee = other.gameObject.GetComponentInParent<Frisbee>();
            BaseMovement character;
            character = isLeftSide ? stadium.lPos : stadium.rPos;
            
            frisbee.SetPlayerPos(character.transform);
            frisbee.SetIsCaught(true);
            character.Frisbee = frisbee;
            character.LockMove();
            stadium.isServing = true;

        }
    }
}
