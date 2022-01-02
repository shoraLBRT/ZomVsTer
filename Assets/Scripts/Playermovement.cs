using UnityEngine;
using Internal;
using System.Collections;
public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private float zom_speed = 10f;
    [SerializeField]
    private float zom_run = 4f;
    [SerializeField]
    private int zom_jump = 200;
    private bool _isGrounded;
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
        _canJump = true;

    }
    private void Update()
    {
        Movable();
        SetAnimationState();
        AttackLogic();
    }
    void Movable()
    {
        if (!_gameCore.IsDead)
        {
            JumpLogic();
            MoveLogic();
            Flip();
        }
    }
    void FixedUpdate()// основные методы
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, zom_speed); //ограничение по скорости
    }

    void Flip() //поворот при ходьбе
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            _spriterend.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            _spriterend.flipX = true;
        }
    }
    private void MoveLogic() // логика движения
    {

        float horiz = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horiz, 0f);
        if (horiz != 0)
        {
            _rb.AddForce(movement * zom_speed); // ходьба
            _isRunning = false;
        }

        if (horiz != 0 && Input.GetKey(KeyCode.LeftShift)) //бег
        {
            _rb.AddForce(movement * zom_run);
            _isRunning = true;
        }

        if (horiz == 0)
        {
            _animatorComponent.SetInteger("state", 0);
            _isRunning = false;
        }
    
    }

    private void JumpLogic()
    {
        if (Input.GetButton("Jump"))
        {
            if (_isGrounded && _canJump)
            {
                _rb.AddForce(Vector2.up * zom_jump);
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

      private void AttackLogic() // Логика атаки пока не готова
      {
          if (Input.GetKey("e"))
          {
              if (_isRunning == false)
              {
                  _animatorComponent.SetInteger("state", 4);
              }
          }

      }
    void OnCollisionEnter2D(Collision2D grounded) //чтоб прыгал только от земли
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
    void SetAnimationState()//анимации
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
