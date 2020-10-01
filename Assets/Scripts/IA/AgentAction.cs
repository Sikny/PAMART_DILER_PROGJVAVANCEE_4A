using System.Collections.Generic;
using UnityEngine;

namespace IA {
    public abstract class AgentAction {
        public List<AgentAction> NextActions;
        public BaseMovement baseMovement;

        // player pos
        public Vector2 Position;

        public void InitNexts() {
            NextActions = new List<AgentAction>();
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    var toAdd = new ActionMove(new Vector2Int(i, j));
                    toAdd.baseMovement = baseMovement;
                    NextActions.Add(toAdd);
                }
            }
            // TODO INTERACT
        }
        
        // proba
        private int _winCount;
        private int _simulCount;
        
        protected Vector2Int Direction;
        public void AddSimulationResult(int numberVictory) {
            ++_simulCount;
            _winCount += numberVictory;
        }
    
        public int GetSimulationResult() {
            return _winCount/_simulCount;
        }

        public abstract void DoAction();

        public abstract void PlayAction();

        protected void UpdateNextActions() {
            foreach (var action in NextActions) {
                action.Position = Position;
            }
        }
    }
    
    public class ActionMove : AgentAction {

        public ActionMove(Vector2Int dir) {
            
            Direction = dir;
        }
    
        public override void DoAction() {
            baseMovement.SetMove(Direction);
        }

        public override void PlayAction() {
            Position = baseMovement.GetDestination(Position, Direction);
            UpdateNextActions();
        }
    }

    // dash / throw
    /*public class ActionInteract : AgentAction {
        public override void DoAction() {
            //BaseMovement.Interact(Random.Range(0, 2));
        }
    }*/
}