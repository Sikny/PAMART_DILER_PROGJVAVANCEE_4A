using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BaseMovement baseMovement;
    
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            baseMovement.SetMoveRight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            baseMovement.UnsetMoveRight();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            baseMovement.SetMoveLeft();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            baseMovement.UnsetMoveLeft();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            baseMovement.SetMoveUp();
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            baseMovement.UnsetMoveUp();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            baseMovement.SetMoveDown();
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            baseMovement.UnsetMoveDown();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            baseMovement.Dash();
        }

    }
}
