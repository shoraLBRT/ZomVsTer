using Internal;
using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    private GameCore _gameCore;

    private Animator _animatorComponent;
    private Rigidbody2D _rb;

    private enum AnimationState { idle, walk, run, jump, attack, hurt, die };
    private AnimationState currentAnimationState;
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();

        _rb = GetComponentInChildren<Rigidbody2D>();
        _animatorComponent = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        AnimationSettings();
        Flip();
    }
    void Flip()
    {
        if (_rb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1f, 1, 1);
            _gameCore.IsFliped = false;
        }
        else if (_rb.velocity.x < 0)
        {
            _gameCore.IsFliped = true;
            gameObject.transform.localScale = new Vector3(-1f, 1, 1);
        }
    }
    private void AnimationSettings()
    {
        if (_rb.velocity.y != 0)
        {
            SetAnimationState(AnimationState.jump);
        }
        if (_rb.velocity.y == 0 && _rb.velocity.x != 0)
        {
            SetAnimationState(AnimationState.walk);
            if (Input.GetKey(KeyCode.LeftShift))
                SetAnimationState(AnimationState.run);
        }
        if (_rb.velocity.x == 0 && _rb.velocity.y == 0)
            SetAnimationState(AnimationState.idle);
        if (_gameCore.IsHurted)
            SetAnimationState(AnimationState.hurt);
        if (_gameCore.IsDead)
            SetAnimationState(AnimationState.die);
        if (Input.GetButtonDown("Fire1"))
            SetAnimationState(AnimationState.attack);
    }
    private void SetAnimationState(AnimationState state)
    {
        currentAnimationState = state;
        _animatorComponent.SetInteger("state", (int)currentAnimationState);
    }
}
