using System;
using System.Collections.Generic;
using Movement;
using TMPro;
using UnityEngine;

public class Stadium : MonoBehaviour {
    public List<Goal> lGoals;
    public List<Goal> rGoals;
    
    public SelectedAgent rightAgent;
    public SelectedAgent leftAgent;
    
    public Transform lSpawn;
    public Transform rSpawn;

    [HideInInspector]
    public bool isServing;
    
    [HideInInspector] public TextMeshProUGUI rScore;
    [HideInInspector] public TextMeshProUGUI lScore;
    
    private PlayerScore _lPlayerScore;
    private PlayerScore _rPlayerScore;

    private void Awake() {
        if (!GameManager.Instance) return;

        GameManager.Instance.IsFinished = false;

  
        GameObject player1 = Instantiate(rightAgent.agentPrefab, rSpawn.position, Quaternion.Euler(0, 0, 90));
        PlayerController controller = player1.GetComponent<PlayerController>();
        if(controller != null) MapPlayer(rightAgent, controller);
        player1.GetComponent<BaseMovement>().offsetFrisbee = rightAgent.xFrisbeeOffset;

        GameObject player2 = Instantiate(leftAgent.agentPrefab, lSpawn.position, Quaternion.Euler(0, 0, -90));

        GameManager.Instance.rPos = player1.GetComponent<BaseMovement>();
        GameManager.Instance.lPos = player2.GetComponent<BaseMovement>();
        controller = player2.GetComponent<PlayerController>();
        if(controller != null) MapPlayer(leftAgent, controller);
        player2.GetComponent<BaseMovement>().offsetFrisbee = leftAgent.xFrisbeeOffset;
        
        
                
        _rPlayerScore = new PlayerScore(rScore, player1.GetComponent<PlayerScoreCharacter>());
        _lPlayerScore = new PlayerScore(lScore, player2.GetComponent<PlayerScoreCharacter>());
        
        foreach (var goal in lGoals) {
            goal.Init(_rPlayerScore);
        }
        foreach (var goal in rGoals) {
            goal.Init(_lPlayerScore);
        }

        GameManager.Instance.soundManager.StopPlayingAllMusics();
        GameManager.Instance.soundManager.Play("PlayTheme");
    }

    private void MapPlayer(SelectedAgent agent, PlayerController controller) {
        controller.InitControls(agent.right, agent.left, agent.up, agent.down, agent.dash);
    }
}
