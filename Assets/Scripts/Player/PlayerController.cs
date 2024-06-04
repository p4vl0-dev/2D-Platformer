using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _playerSpeed, _jumpHeight, _circleRadius;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _pointToCheck;
    private Vector2 iternalDirection;

    void Start()
    {
        if(_rigidBody2D==null)
            _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isOnGround();
    }

    private void FixedUpdate()
    {
        MoveIternal();
    }

    public void Jump()
    {
        if(isOnGround())
        {
            _rigidBody2D.AddForce(Mathf.Sqrt(2 * _rigidBody2D.gravityScale * _jumpHeight) * Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void Move(Vector2 moveDirection)
    {
        iternalDirection = moveDirection;
    }

    private void MoveIternal()
    {
        _rigidBody2D.velocity = new Vector2(iternalDirection.x * _playerSpeed, _rigidBody2D.velocity.y);
    }

    private bool isOnGround()
    {
        return Physics2D.OverlapCircle(_pointToCheck.position, _circleRadius, _groundMask);
    }
}
