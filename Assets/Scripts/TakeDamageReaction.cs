using Internal;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class TakeDamageReaction : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;
    private Animator _animatorComponent;

    private GameCore _gameCore;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();
        _animatorComponent = GetComponent<Animator>();
        _gameCore = Locator.GetObject<GameCore>();
    }
    private void Update()
    {
        if (_rb.velocity.y == 0)
        {
            _spriterend.color = Color.white;
            _gameCore.CanMoving = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) // получение урона
    {

        if (!_gameCore.IsDead)
        {
            if (collision.gameObject.tag == ("Enemy"))
            {
                //_rb.velocity = new Vector2(_rb.velocity.x, 20f);
                _rb.AddForce(Vector2.up * 500f);
                if (_spriterend.flipX == false)
                    _rb.AddForce(Vector2.left * 500f);  
                if (_spriterend.flipX == true)
                    _rb.AddForce(Vector2.right * 500f);
                _animatorComponent.SetInteger("state", 5);
                _spriterend.color = Color.red;
                _gameCore.CanMoving = false;
            }
        }
    }
}
