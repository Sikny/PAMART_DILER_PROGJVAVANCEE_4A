using System;
using System.Collections.Generic;
using Movement;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace IA {
    public enum PlayerSide {
        Left, Right
    }
    
    public class MCTSHandler : MonoBehaviour {
        public PlayerMCTS playerMcts;
        public BaseMovement opponent;
        public Vector2 opponentPos;
        private InteractorSimulated opponentInteractor;

        private Frisbee _frisbee;
        private FrisbeeSimulated _frisbeeSimulated;

        [HideInInspector] public SimulateScoreTime scoreTime;

        [HideInInspector] public PlayerSide side;
        
        private bool IsFinished() {
            if (scoreTime.GetTime() <= 0.01f)
                return true;
            if (scoreTime.LScore >= 12 && side == PlayerSide.Left
                || scoreTime.RScore >= 12 && side == PlayerSide.Right)
                return true;
            return false;
        }

        // 0 : lose, 1 : win
        private float Result() {
            if (scoreTime.LScore > scoreTime.RScore && side == PlayerSide.Left
                || side == PlayerSide.Right && scoreTime.RScore > scoreTime.LScore) {
                return 1;
            }
            if (scoreTime.LScore == scoreTime.RScore) {
                return 0.5f;
            }
            return 0;
        }

        private Stadium _stadium;

        public void InitAwake() {
            if (_frisbee == null) _frisbee = FindObjectOfType<Frisbee>();
            if (_stadium == null) _stadium = FindObjectOfType<Stadium>();
        }
        public void Init() {
            scoreTime = new SimulateScoreTime();
            scoreTime.Init(GameManager.Instance.timer.CurrentTime);
            scoreTime.LScore = _stadium.LPlayerScore.GetScore();
            scoreTime.RScore = _stadium.RPlayerScore.GetScore();
            _frisbeeSimulated = new FrisbeeSimulated {
                Position = _frisbee.transform.position,
                ColliderRadius = _frisbee.circleCollider.radius,
                Direction = _frisbee.Direction,
                Force = _frisbee.Force
            };
            opponentPos = opponent.transform.position;
            opponentInteractor = new InteractorSimulated();
            opponentInteractor.Position = opponentPos;
        }
        
        public void ComputeMCTS() {
            float max = Single.MinValue;
            AgentAction bestAction = null;
            foreach(var possibleAction in GetPossibleActions()) //Expansion
            {
                float numberVictory = SimulateResult(possibleAction); //Simulation (a faire plusieurs fois !)
                possibleAction.AddSimulationResult(numberVictory); //Retropropagation
                if(max < possibleAction.GetSimulationResult()) //SimulationResult > -1
                {
                    max = possibleAction.GetSimulationResult();
                    bestAction = possibleAction;
                }
                
                scoreTime.Init(GameManager.Instance.timer.CurrentTime);
                scoreTime.LScore = _stadium.LPlayerScore.GetScore();
                scoreTime.RScore = _stadium.RPlayerScore.GetScore();
            }
            bestAction?.DoAction();
        }
        
        // une simulation = 1 win | 0 lose
        private float SimulateResult(AgentAction possibleAction) {
            Vector2 opponentSimulatedPos = opponentPos;
            InteractorSimulated opponentInteractorSimulated = opponentInteractor;
            //return scoreCharacter.Result();
            int crashHandler = 10000;
            AgentAction selectedAction = null;
            while(!IsFinished() && crashHandler > 0) //Attention votre jeu doit être finit !
            {
                --crashHandler;
                List<AgentAction> actions;
                if (selectedAction == null)
                    actions = GetPossibleActions(possibleAction);
                else
                    actions = GetPossibleActions(selectedAction);

                selectedAction = GetRandomAction(actions);
            
                selectedAction.PlayAction();
                scoreTime.UpdateTimer();
                _frisbeeSimulated.UpdateFrisbee();
                opponentSimulatedPos = RandomActionOpponent(opponentSimulatedPos);
                int result = _frisbeeSimulated.HandleCollisionWithPlayer(selectedAction.Position, opponentSimulatedPos, opponent.selfCollider.radius);
                if (result != 0) {
                    if (result == 1) {
                        selectedAction.InteractorSimulated.Frisbee = _frisbeeSimulated;
                        _frisbeeSimulated.UpdateOffset(selectedAction.baseMovement.offsetFrisbee);
                    } else if (result == 2) {
                        opponentInteractorSimulated.Frisbee = _frisbeeSimulated;
                        _frisbeeSimulated.UpdateOffset(opponent.offsetFrisbee);
                    }
                }
            }
            return Result(); //0 si perdu 1 si win*/
        }
        
        private Vector2 RandomActionOpponent(Vector2 opponentSimulatedPos) {
            Vector2Int directionHeld = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));

            opponentSimulatedPos = opponent.GetDestination(opponentSimulatedPos, directionHeld);
            return opponentSimulatedPos;

            //opponent.SetMove(directionHeld);

            /*int action = Random.Range(0, 2);
            if(action == 1)
                opponent.Interact(directionHeld);*/
        }

        private List<AgentAction> GetPossibleActions(AgentAction current = null) {
            var actions = new List<AgentAction>();
            Vector2 playerPos;
            InteractorSimulated interactor;
            if (current == null) {
                playerPos = playerMcts.transform.position;
                interactor = new InteractorSimulated();
            }
            else {
                playerPos = current.Position;
                interactor = current.InteractorSimulated;
            }
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    var dir = new Vector2Int(i, j);
                    actions.Add(new ActionMove(playerPos, dir, playerMcts.baseMvt, interactor));
                    actions.Add(new ActionInteract(playerPos, dir, playerMcts.baseMvt, interactor));
                }
            }

            return actions;
        }
        
        private AgentAction GetRandomAction(List<AgentAction> actions) {
            return actions[Random.Range(0, actions.Count)];
        }
    }
}
