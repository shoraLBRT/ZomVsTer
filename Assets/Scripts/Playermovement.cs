using UnityEngine;
using Internal;
using System.Collections;
public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private float zom_walk;
    [SerializeField]
    private float zom_run;
    private float _horiz;

    private bool _canJump;
    private bool _isRunning;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;
    private Animator _animatorComponent;

    private GameCore _gameCore;

    private enum AnimationState { idle, run, jump, walk };
    private AnimationState currentAnimationState = AnimationState.idle;

    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();
        _animatorComponent = GetComponent<Animator>();

        _gameCore.IsDead = false;
        _gameCore.CanMoving = true;
        _canJump = true;
        //_gameCore.IsGrounded = true;

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
        SetAnimationState();
    }
    void Flip() //поворот при ходьбе
    {
        if (_horiz > 0)
        {
            _spriterend.flipX = false;
        }
        if (_horiz < 0)
        {
            _spriterend.flipX = true;
        }
    }
    private void MoveLogic() // логика движения
    {

        _horiz = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(_horiz, 0f);
        if (_horiz != 0)
        {
            _rb.velocity = new Vector2(_horiz * zom_walk, _rb.velocity.y);
            //_rb.AddForce(movement * zom_speed); // другая реализация ходьбы
        }

        if (_horiz != 0 && Input.GetKey(KeyCode.LeftShift)) //бег
        {
            _rb.velocity = new Vector2(_horiz * zom_run, _rb.velocity.y);
            //_rb.AddForce(movement * zom_run); другая реализация бега
            _isRunning = true;
        }

        if (_horiz == 0)
        {
            _animatorComponent.SetInteger("state", 0);
            _isRunning = false;
        }
    
    }

    private void JumpLogic()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_rb.velocity.y == 0 && _canJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, 20);
                //_rb.AddForce(Vector2.up * zom_jump); // другая реализация прыжка
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
          if (Input.GetKey("e"))
          {
              if (_isRunning == false)
              {
                  _animatorComponent.SetInteger("state", 4);
              }
          }

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
    void SetAnimationState()//анимации здесь не нужны, надо вывести в другой класс
    {
        if (Mathf.Abs(_rb.velocity.x) > 0.1)
        {
            currentAnimationState = AnimationState.walk;
            if (Input.GetKey(KeyCode.LeftShift))
                currentAnimationState = AnimationState.run;
        }

        else
            currentAnimationState = AnimationState.idle;

        if (Mathf.Abs(_rb.velocity.y) > 0.1)
            currentAnimationState = AnimationState.jump;

        _animatorComponent.SetInteger("state", (int)currentAnimationState);
    }

}
