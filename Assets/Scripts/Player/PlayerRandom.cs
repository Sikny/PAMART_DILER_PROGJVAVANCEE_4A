using UnityEngine;

public class PlayerRandom : MonoBehaviour {
    public BaseMovement baseMovement;
    private int _directionHeld;

    void Update() {
        baseMovement.SetLateralMove(Random.Range(-1, 2));
        _directionHeld = Random.Range(-1, 2);
        baseMovement.SetVerticalMove(_directionHeld);

        int doDash = Random.Range(0, 2);
        if (doDash == 1) {
            if(!baseMovement.Frisbee)
                baseMovement.Dash();
            else baseMovement.ThrowFrisbee(_directionHeld);
        }
    }
}
