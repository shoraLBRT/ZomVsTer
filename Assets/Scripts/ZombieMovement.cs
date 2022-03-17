using System.Collections;
using UnityEngine;
public class ZombieMovement : MonoBehaviour
{
    private float zom_walk;
    private float zom_run;
    private float _horiz;

    private bool _canJump;

    private bool _canMoving;

    private Rigidbody2D _rb;

    public bool CanMoving { get => _canMoving; set => _canMoving = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canJump = true;

        zom_walk = 9f;
        zom_run = 15f;
    }
    private void FixedUpdate()
    {
        if (CanMoving)
        {
            NonFriction();
            MoveLogic();
        }
    }
    private void Update()
    {
        if (CanMoving)
            JumpLogic();
    }
    private void MoveLogic()
    {
        _horiz = Input.GetAxis("Horizontal");
        if (_horiz != 0)
            _rb.velocity = new Vector2(_horiz * zom_walk, _rb.velocity.y);

        if (_horiz != 0 && Input.GetKey(KeyCode.LeftShift))
            _rb.velocity = new Vector2(_horiz * zom_run, _rb.velocity.y);
    }

    private void JumpLogic()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_rb.velocity.y == 0 && _canJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, 20);
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
}