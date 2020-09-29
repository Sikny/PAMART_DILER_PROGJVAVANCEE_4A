using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{

    public PlayerCollision playerCollision;
    public float speed = 1.0f;

    private float _initialSpeed;
    private bool _isDashing;
    private bool _inDashCooldown; 
    
    private bool _isMovingRight;
    private bool _isMovingLeft;
    private bool _isMovingUp;
    private bool _isMovingDown;

    private int xAxis = 0;
    private int yAxis = 0;

    private int xAxisStartDash = 0;
    private int yAxisStartDash = 0;
    private void Update()
    {
        if (_isDashing)
        {
            DoDash();
            return;
        }

        if (xAxis == 1) //moving right
        {
            Vector2 pos = transform.position;
            Vector2 dest = new Vector2(pos.x + 0.1f, pos.y);
            transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
        }

        if (xAxis == -1) //moving left
        {
            Vector2 pos = transform.position;
            Vector2 dest = new Vector2(pos.x - 0.1f, pos.y);
            transform.position = Vector2.MoveTowards(pos, dest,  speed * Time.deltaTime);
        }

        if (yAxis == 1) //moving up
        {
            Vector2 pos = transform.position;
            Vector2 dest = new Vector2(pos.x, pos.y + 0.1f);
            transform.position = Vector2.MoveTowards(pos, dest,  speed * Time.deltaTime);
        }
        if (yAxis == -1) //moving down
        {
            Vector2 pos = transform.position;
            Vector2 dest = new Vector2(pos.x, pos.y - 0.1f);
            transform.position = Vector2.MoveTowards(pos, dest,  speed * Time.deltaTime);
        }

    }
    public void SetMoveRight()
    {
        xAxis += 1;
    }
    public void SetMoveLeft()
    {
        xAxis -= 1;
    }

    public void SetMoveUp()
    {
        yAxis += 1;
    }
    public void SetMoveDown()
    {
        yAxis -= 1;
    }
    public void UnsetMoveRight()
    {
        xAxis -= 1;
    }

    public void UnsetMoveLeft()
    {
        xAxis += 1;
    }

    public void UnsetMoveUp()
    {
        yAxis += -1;
    }
    
    public void UnsetMoveDown()
    {
        yAxis -= -1;
    }
    public void Dash()
    {

        if (_isDashing) return;
        xAxisStartDash = xAxis;
        yAxisStartDash = yAxis;
        _isDashing = true;
        StartCoroutine(StartDash(0.15f));

    }

    private void DoDash()
    {
        var position = transform.position;
        Vector2 dest = new Vector2(position.x + xAxisStartDash, position.y + yAxisStartDash);
        position = Vector2.MoveTowards(position, dest,  speed * 6 *  Time.deltaTime);
        transform.position = position;
    }

    private IEnumerator StartDash(float dashLength)
    {
        _initialSpeed = speed;
        yield return new WaitForSeconds(dashLength);
        _isDashing = false;
    }


    public int XAxis
    {
        get => xAxis;
        set => xAxis = value;
    }

    public int YAxis
    {
        get => yAxis;
        set => yAxis = value;
    }
}
