using Movement;
using UnityEngine;

namespace IA {
    public class AgentAction {
        public BaseMovement baseMovement;
        public InteractorSimulated InteractorSimulated;

        protected void Init(Vector2 position, Vector2Int dir, BaseMovement baseMvt, InteractorSimulated interactor) {
            Position = position;
            Direction = dir;
            baseMovement = baseMvt;
            InteractorSimulated = interactor;
            InteractorSimulated.Position = position;
        }
        
        // player pos
        public Vector2 Position;
        
        // proba
        private float _winCount;
        private int _simulCount;
        
        protected Vector2Int Direction;
        public void AddSimulationResult(float numberVictory) {
            // todo
            ++_simulCount;
            _winCount += numberVictory;
        }
    
        public float GetSimulationResult() {
            return _winCount/_simulCount;
        }

        // Chosen, executed in runtime
        public virtual void DoAction() {
            
        }

        // Simulation only
        public virtual void PlayAction() {
            
        }
    }
    
    public class ActionMove : AgentAction {

        public ActionMove(Vector2 position, Vector2Int dir, BaseMovement baseMvt, InteractorSimulated interactor) {
            Init(position, dir, baseMvt, interactor);
        }
    
        public override void DoAction() {
            baseMovement.SetMove(Direction);
        }
        
        public override void PlayAction() {
            Position = baseMovement.GetDestination(Position, Direction);
        }
    }

    // dash / throw
    public class ActionInteract : AgentAction {
        public ActionInteract(Vector2 position, Vector2Int dir, BaseMovement baseMvt, InteractorSimulated interactor) {
            Init(position, dir, baseMvt, interactor);
        }
        
        public override void DoAction() {
            baseMovement.Interact(Direction);
        }

        public override void PlayAction() {
            InteractorSimulated.Interact(Direction);
        }
    }
}