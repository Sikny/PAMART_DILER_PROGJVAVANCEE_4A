using System.Collections.Generic;
using UnityEngine;

public abstract class AgentAction : MonoBehaviour {
    private float proba;    // proba de selectionner l'action
    private List<AgentAction> _possibleActions;
    public void AddSimulationResult(int numberVictory) {
        
    }
    
    public int GetSimulationResult() {
        return 0;
    }

    public List<AgentAction> GetPossibleAction() {
        return _possibleActions;
    }

    public abstract void DoAction();
}

public class ActionLeft : AgentAction {
    public override void DoAction() {
        
    }
}

public class ActionRight : AgentAction {
    public override void DoAction() {
        
    }
}

public class ActionTop : AgentAction {
    public override void DoAction() {
        
    }
}

public class ActionBottom : AgentAction {
    public override void DoAction() {
        
    }
}