using System;
using TMPro;
using UnityEngine;

public class OptionsManager : MonoBehaviour {
    public TMP_Dropdown lDropDown;
    public TMP_Dropdown rDropDown;

    public SelectedAgent lAgent;
    public SelectedAgent rAgent;

    private void FixedUpdate() {
        if (GameManager.Instance)
            GameManager.Instance.optionsManager = this;
    }

    public void Init() {
        lDropDown.value = GameManager.Instance.possibleAgents.IndexOf(lAgent.agentPrefab);
        rDropDown.value = GameManager.Instance.possibleAgents.IndexOf(rAgent.agentPrefab);
    }
}
