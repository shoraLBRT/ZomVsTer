using Internal;
using UnityEngine;

public class TakeDamageReaction : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;

    private GameCore _gameCore;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();
        _gameCore = Locator.GetObject<GameCore>();
    }
    private void Update()
    {
        if (_rb.velocity.y == 0)
        {
            _spriterend.color = Color.white;
            _gameCore.CanMoving = true;
            _gameCore.IsHurted = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) // получение урона
    {

        if (!_gameCore.IsDead)
        {
            if (collision.gameObject.tag == ("Enemy"))
            {
                _rb.AddForce(Vector2.up * 500f);
                if (_spriterend.flipX == false)
                    _rb.AddForce(Vector2.left * 500f);
                if (_spriterend.flipX == true)
                    _rb.AddForce(Vector2.right * 500f);
                _spriterend.color = Color.red;
                _gameCore.CanMoving = false;
            }
        }
    }
}
