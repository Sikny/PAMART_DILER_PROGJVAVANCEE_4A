using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BaseMovement baseMovement;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            baseMovement.MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            baseMovement.MoveDown();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            baseMovement.MoveLeft();
        }       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            baseMovement.MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            baseMovement.Dash();
        }
    }
}
