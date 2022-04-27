using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMoving = true;

    private void FixedUpdate()
    {
        if(_isMoving == true)
            transform.Rotate(0,0,_speed);
        else
            transform.Rotate(0,0,-_speed);
    }

    public void ReverseDirection()
    {
        _isMoving = !_isMoving;
    }
}
