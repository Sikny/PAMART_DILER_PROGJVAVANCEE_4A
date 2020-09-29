using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BaseMovement baseMovement;
    private int _directionHeld = 0;
    // Update is called once per frame
    void Update()
    {
    
        // Lateral
        if (Input.GetKey(KeyCode.RightArrow))
        {
            baseMovement.SetLateralMove(1);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            baseMovement.SetLateralMove(-1);
        }
        else {
            baseMovement.SetLateralMove(0);
        }
        
        // Vertical
        if (Input.GetKey(KeyCode.UpArrow))
        {
            baseMovement.SetVerticalMove(1);
            _directionHeld = 1;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            baseMovement.SetVerticalMove(-1);
            _directionHeld = -1;
        }
        else {
            baseMovement.SetVerticalMove(0);
            _directionHeld = 0;
        }
        
        // Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!baseMovement.Frisbee)
                baseMovement.Dash();
            else
            {
                Debug.Log("direction : " + _directionHeld);
                baseMovement.ThrowFrisbee(_directionHeld);
            }
        }

    }
}
