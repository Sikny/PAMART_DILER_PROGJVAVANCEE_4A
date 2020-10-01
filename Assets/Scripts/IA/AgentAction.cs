using System.Collections.Generic;

public abstract class AgentAction {
    public List<AgentAction> nextPossibleActions = new List<AgentAction>() {
        new ActionBottom(), new ActionInteract(), new ActionLeft(), new ActionRight(), new ActionTop()
    };
    private int _winCount;
    private int _simulCount;
    public void AddSimulationResult(int numberVictory) {
        ++_simulCount;
        _winCount += numberVictory;
    }
    
    public int GetSimulationResult() {
        return _winCount/_simulCount;
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

public class ActionInteract : AgentAction {
    public override void DoAction() {
        
    }
}