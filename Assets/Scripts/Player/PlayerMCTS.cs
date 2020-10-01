using System;
using System.Collections.Generic;
using IA;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player {
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public class PlayerMCTS : MonoBehaviour {
        private AgentActionsNode _currentNode;
        private PlayerScoreCharacter _scoreCharacter;

        private void Awake() {
            _currentNode = new AgentActionsNode();
        }

        private void ComputeMCTS() {
            int max = Int32.MinValue;
            AgentAction bestAction = null;
            foreach(var possibleAction in _currentNode.possibleActions) //Expansion
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
            // TODO
            return null;
        }

    }
}
