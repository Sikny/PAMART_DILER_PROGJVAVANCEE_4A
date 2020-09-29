using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stadium : MonoBehaviour {
    public List<Goal> lGoals;
    public List<Goal> rGoals;

    public TextMeshProUGUI rScore;
    public TextMeshProUGUI lScore;

    private PlayerScore _lPlayerScore;
    private PlayerScore _rPlayerScore;
    
    private void Awake() {
        _lPlayerScore = new PlayerScore(lScore);
        _rPlayerScore = new PlayerScore(rScore);
        // left goal = add score for right player
        // right goal = add score for left player
        foreach (var goal in lGoals) {
            goal.Init(_rPlayerScore);
        }
        foreach (var goal in rGoals) {
            goal.Init(_lPlayerScore);
        }
    }
}
