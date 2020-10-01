using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BaseMovement baseMovement;
    private Vector2Int _directionHeld;

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
        if (Input.GetKey(_rightKey)) {
            _directionHeld.x = 1;
        }
        else if(Input.GetKey(_leftKey)) {
            _directionHeld.x = -1;
        }
        else {
            _directionHeld.x = 0;
        }
        
        // Vertical
        if (Input.GetKey(_upKey))
        {
            _directionHeld.y = 1;
        } else if (Input.GetKey(_downKey)) {
            _directionHeld.y = -1;
        }
        else {
            _directionHeld.y = 0;
        }
        
        baseMovement.SetMove(_directionHeld);
        
        // Dash
        if (Input.GetKeyDown(_dashKey))
        {
            baseMovement.Interact(_directionHeld);
        }

    }
}
