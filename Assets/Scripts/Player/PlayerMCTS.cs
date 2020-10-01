using System;
using System.Collections.Generic;
using IA;
using Movement;
using UnityEngine;
using Random = UnityEngine.Random;
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace Player {
    public class PlayerMCTS : MonoBehaviour {
        public PlayerScoreCharacter scoreCharacter;
        public BaseMovement baseMvt;
        private AgentAction _currentNode;

        private void Awake() {
            _currentNode = new ActionMove(new Vector2Int(0, 0));
            _currentNode.baseMovement = baseMvt;
            _currentNode.InitNexts();
        }

        private void Update() {
            ComputeMCTS();
        }

        // 1 step
        private void ComputeMCTS() {
            int max = Int32.MinValue;
            AgentAction bestAction = null;
            foreach(var possibleAction in _currentNode.NextActions) //Expansion
            {
                int numberVictory = SimulateResult(possibleAction); //Simulation (a faire plusieurs fois !)
                possibleAction.AddSimulationResult(numberVictory); //Retropropagation
                if(max < possibleAction.GetSimulationResult()) //SimulationResult > -1
                {
                    max = possibleAction.GetSimulationResult();
                    bestAction = possibleAction;
                }
            }
            bestAction?.DoAction();
        }
    
        // une simulation = 1 win | lose
        private int SimulateResult(AgentAction possibleAction) {
            return scoreCharacter.Result();
            while(!GameManager.Instance.IsFinished) //Attention votre jeu doit être finit !
            {
                List<AgentAction> actions = GetNextPossibleActions(possibleAction);
            
                AgentAction selectedAction = GetRandomAction(actions);
            
                // TODO SIMULATION
                selectedAction.PlayAction();
                //Game.PlayAction(selectedAction);
            
            }

            return scoreCharacter.Result(); //0 si perdu 1 si win*/
        }

        private AgentAction GetRandomAction(List<AgentAction> actions) {
            return actions[Random.Range(0, actions.Count)];
        }

        private List<AgentAction> GetNextPossibleActions(AgentAction possibleAction) {
            List<AgentAction> actions = new List<AgentAction>();
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    actions.Add(new ActionMove(new Vector2Int(i, j)));
                }
            }
            // TODO INTERACT
            return actions;
        }
    }
}
