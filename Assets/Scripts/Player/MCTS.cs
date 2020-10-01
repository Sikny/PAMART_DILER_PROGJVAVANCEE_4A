using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MCTS : MonoBehaviour {
    private AgentActionsNode CurrentNode;
    private PlayerScoreCharacter _scoreCharacter;
    
    private void ComputeMCTS() {
        int max = Int32.MinValue;
        AgentAction bestAction = null;
        foreach(var possibleAction in CurrentNode.possibleActions) //Expansion
        {
            int numberVictory = SimulateResult(possibleAction); //Simulation (a faire plusieurs fois !)
            possibleAction.AddSimulationResult(numberVictory); //Retropropagation
            if(max < possibleAction.GetSimulationResult()) //SimulationResult > -1
            {
                max = possibleAction.GetSimulationResult();
                bestAction = possibleAction;
            }
        }
    }
    
    // une simulation = 1 win | lose
    private int SimulateResult(AgentAction possibleAction)
    {
        while(!GameManager.Instance.IsFinished) //Attention votre jeu doit être finit !
        {
            List<AgentAction> actions = GetNextPossibleActions(possibleAction);
            
            AgentAction selectedAction = GetRandomAction(actions);
            
            // TODO SIMULATION
            //Game.PlayAction(selectedAction);
            
        }

        return _scoreCharacter.Result(); //0 si perdu 1 si win*/
    }

    private AgentAction GetRandomAction(List<AgentAction> actions) {
        return actions[Random.Range(0, actions.Count)];
    }

    private List<AgentAction> GetNextPossibleActions(AgentAction action) {
        return action.nextPossibleActions;
    }

}
