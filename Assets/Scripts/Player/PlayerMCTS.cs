using IA;
using Movement;
using UnityEngine;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace Player {
    public class PlayerMCTS : MonoBehaviour {
        public BaseMovement baseMvt;
        [HideInInspector] public AgentAction currentAction;
        public MCTSHandler handlerPrefab;
        private MCTSHandler handler;

        public float delayBetweenSimulations = 1f;
        private float lastSimulation;

        private void Awake() {
            currentAction = new ActionMove(transform.position, new Vector2Int(0, 0), baseMvt, 
                new InteractorSimulated());
            lastSimulation = delayBetweenSimulations;
        }

        private void Update() {
            lastSimulation -= Time.deltaTime;
            if (lastSimulation <= 0) {
                lastSimulation = delayBetweenSimulations;
                handler.Init();
                handler.ComputeMCTS();
            }
        }
        
        public void InitHandler(PlayerSide side, BaseMovement otherPlayer) {
            handler = Instantiate(handlerPrefab);
            handler.playerMcts = this;
            handler.opponent = otherPlayer;
            handler.side = side;
            handler.InitAwake();
        }
    }
}
