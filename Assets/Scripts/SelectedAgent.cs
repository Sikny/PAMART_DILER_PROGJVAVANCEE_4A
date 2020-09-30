using UnityEngine;


[CreateAssetMenu(fileName = "SelectedAgent", menuName = "ScriptableObjects/SelectedAgent")]
public class SelectedAgent : ScriptableObject {
    public GameObject agentPrefab;

    public float xFrisbeeOffset;

    #region KeyMap
    [Header("Keymap")]
    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;
    public KeyCode dash;
    #endregion

    public void SetAgent(int id) {
        agentPrefab = GameManager.Instance.possibleAgents[id];
    }
}
