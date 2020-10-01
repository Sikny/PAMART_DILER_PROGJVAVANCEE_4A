using System;
using System.Collections.Generic;
using UnityEngine;

public class MCTS : MonoBehaviour {
    private AgentActionsNode CurrentNode;
    
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
        while(!GameManager.Instance.IsFinished()) //Attention votre jeu doit être finit !
        {
            //List<AgentAction> actions = Game.GetNextPossibleAction(possibleAction);
            //AgentAction selectedAction = Game.GetRandomAction(actions);
            //Game.PlayAction(selectedAction);
            
        }

        return 0; //Game.Result(); //0 si perdu 1 si win*/
    }

}
