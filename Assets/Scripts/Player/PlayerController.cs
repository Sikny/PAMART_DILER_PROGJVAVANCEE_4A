using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BaseMovement baseMovement;
    private int _directionHeld;

    private KeyCode _rightKey;
    private KeyCode _leftKey;
    private KeyCode _upKey;
    private KeyCode _downKey;
    private KeyCode _dashKey;
    
    public void InitControls(KeyCode right, KeyCode left, KeyCode up, KeyCode down, KeyCode dash) {
        _rightKey = right;
        _leftKey = left;
        _upKey = up;
        _downKey = down;
        _dashKey = dash;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Lateral
        if (Input.GetKey(_rightKey))
        {
            baseMovement.SetLateralMove(1);
        }
        else if(Input.GetKey(_leftKey)) {
            baseMovement.SetLateralMove(-1);
        }
        else {
            baseMovement.SetLateralMove(0);
        }
        
        // Vertical
        if (Input.GetKey(_upKey))
        {
            baseMovement.SetVerticalMove(1);
            _directionHeld = 1;
        } else if (Input.GetKey(_downKey)) {
            baseMovement.SetVerticalMove(-1);
            _directionHeld = -1;
        }
        else {
            baseMovement.SetVerticalMove(0);
            _directionHeld = 0;
        }
        
        // Dash
        if (Input.GetKeyDown(_dashKey))
        {
            if (!baseMovement.Frisbee)
                baseMovement.Dash();
            else
            {
                baseMovement.ThrowFrisbee(_directionHeld);
            }
        }

    }
}
