using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartMovement : MonoBehaviour
{
    private float _bodypart_walk;
    private int _jumpforce;
    private float _horiz;

    private bool _canJump;
    private bool _isGrounded;

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _canJump = true;
        _bodypart_walk = 9f;
        _jumpforce = 15;
    }
    private void FixedUpdate()
    {
        NonFriction();
        MoveLogic();
    }
    private void Update()
    {
        JumpLogic();
    }
    private void MoveLogic()
    {
        _horiz = Input.GetAxis("Horizontal");
        if (_horiz != 0)
            _rb.velocity = new Vector2(_horiz * _bodypart_walk, _rb.velocity.y);
    }

    private void JumpLogic()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded && _canJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpforce);
                _canJump = false;
                StartCoroutine(ResetJumping());
            }
        }
    }
    private void NonFriction()
    {
        if (_rb.velocity.y == 0 && _rb.velocity.x < 1)
            _rb.velocity = Vector2.zero;
    }

    private IEnumerator ResetJumping()
    {
        yield return new
            WaitForSeconds(0.2f);
        _canJump = true;
    }
    void OnCollisionStay2D(Collision2D grounded)
    {
        IsGroundedUpdate(grounded, true);
    }
    private void OnCollisionExit2D(Collision2D grounded)
    {
        IsGroundedUpdate(grounded, false);
    }
    private void IsGroundedUpdate(Collision2D grounded, bool value)
    {
        if (grounded.gameObject.tag == ("Ground"))
            _isGrounded = value;
    }
}
