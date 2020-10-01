using UnityEngine;

public class PlayerRandom : MonoBehaviour {
    public BaseMovement baseMovement;
    private Vector2Int _directionHeld;

    void Update() {
        _directionHeld = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));
        baseMovement.SetMove(_directionHeld);

        int action = Random.Range(0, 2);
        if(action == 1)
            baseMovement.Interact(_directionHeld);
    }
}
