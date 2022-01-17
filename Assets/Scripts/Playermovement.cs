using UnityEngine;
using Internal;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    private float zom_walk;
    private float zom_run;
    private float _horiz;

    private bool _canJump;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;

    private GameCore _gameCore;

    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();

        _gameCore.IsDead = false;
        _gameCore.CanMoving = true;
        _canJump = true;

        zom_walk = 9f;
        zom_run = 15f;
    }
    private void Update()
    {
        if (_gameCore.CanMoving & !_gameCore.IsDead)
        {
            JumpLogic();
            MoveLogic();
            Flip();
            AttackLogic();
        }
    }
    void Flip() //поворот при ходьбе
    {
        if (_horiz > 0)
            _spriterend.flipX = false;
        if (_horiz < 0)
            _spriterend.flipX = true;
    }
    private void MoveLogic() // логика движения
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

    private IEnumerator ResetJumping()
    {
        yield return new
            WaitForSeconds(0.5f);
        _canJump = true;
    }

      private void AttackLogic() // Логика атаки пока не готова, и здесь не нужна. Надо вывести в другой класс
    {

    }

    //void OnCollisionStay2D(Collision2D grounded) // пока что этот флажок не нужен. Его роль играет _rb.velocity.y == 0
    //{
    //    IsGroundedUpdate(grounded, true);
    //}
    //private void OnCollisionExit2D(Collision2D grounded)
    //{
    //    IsGroundedUpdate(grounded, false);
    //}
    //private void IsGroundedUpdate(Collision2D grounded, bool value)
    //{
    //    if (grounded.gameObject.tag == ("Ground"))
    //        _gameCore.IsGrounded = value;
    //}
}
