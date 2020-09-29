using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stadium : MonoBehaviour {
    public List<Goal> lGoals;
    public List<Goal> rGoals;
    
    public SelectedAgent rightAgent;
    public SelectedAgent leftAgent;
    public Transform lSpawn;
    public Transform rSpawn;

    [HideInInspector] public TextMeshProUGUI rScore;
    [HideInInspector] public TextMeshProUGUI lScore;
    
    private PlayerScore _lPlayerScore;
    private PlayerScore _rPlayerScore;

    private void Awake() {
        if (!GameManager.Instance) return;
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

        GameObject player1 = Instantiate(rightAgent.agentPrefab, rSpawn.position, Quaternion.identity);
        PlayerController controller = player1.GetComponent<PlayerController>();
        if(controller != null) MapPlayer(rightAgent, controller);
        GameObject player2 = Instantiate(leftAgent.agentPrefab, lSpawn.position, Quaternion.identity);
        controller = player2.GetComponent<PlayerController>();
        if(controller != null) MapPlayer(leftAgent, controller);
    }

    private void MapPlayer(SelectedAgent agent, PlayerController controller) {
        controller.InitControls(agent.right, agent.left, agent.up, agent.down, agent.dash);
    }
}
