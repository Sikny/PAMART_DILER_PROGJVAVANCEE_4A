using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{

    public float speed = 1.0f;

    private float _initialSpeed;
    private bool _isDashing;

    public void MoveUp()
    {
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x, pos.y + 0.1f);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x, pos.y - 0.1f);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x + 0.1f, pos.y);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        Vector2 pos = transform.position;
        Vector2 dest = new Vector2(pos.x - 0.1f, pos.y);
        transform.position = Vector2.MoveTowards(pos, dest, speed * Time.deltaTime);
    }

    public void Dash()
    {
        if (_isDashing) return;
        _isDashing = true;
        StartCoroutine(StartDash(0.5f));

    }

    public IEnumerator StartDash(float dashLength)
    {
        _initialSpeed = speed;
        speed *= 50;
        yield return new WaitForSeconds(dashLength);
        speed = _initialSpeed;
        _isDashing = false;

    }
}
