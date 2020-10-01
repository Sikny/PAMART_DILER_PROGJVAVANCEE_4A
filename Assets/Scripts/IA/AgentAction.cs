using UnityEngine;

namespace IA {
    public abstract class AgentAction {
        public BaseMovement BaseMovement;
    
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
    }
    
    public class ActionMove : AgentAction {

        public ActionMove(Vector2Int dir) {
            Direction = dir;
        }
    
        public override void DoAction() {
            BaseMovement.SetMove(Direction);
        }
    }

    // dash / throw
    public class ActionInteract : AgentAction {
        public override void DoAction() {
            //BaseMovement.Interact(Random.Range(0, 2));
        }
    }

    public class ActionInteractBottom : AgentAction {
        public override void DoAction() {
            //BaseMovement.Interact(Random.Range(0, 2), Random.Range(-1, 2));
        }
    }
}