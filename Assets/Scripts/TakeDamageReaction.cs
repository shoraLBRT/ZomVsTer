using Internal;
using UnityEngine;

public class TakeDamageReaction : MonoBehaviour
{
    private GameCore _gameCore;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;

    private bool _canReset;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();

        _gameCore = Locator.GetObject<GameCore>();
    }
    private void Update()
    {
        ResetFromDamage();
    }
    void OnCollisionEnter2D(Collision2D collision) // получение урона
    {
        if (!_gameCore.IsDead)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _canReset = false;
                _spriterend.color = Color.red;
                _gameCore.CanMoving = false;
                if (collision.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    _rb.AddForce(Vector2.up * 300f);
                    _rb.AddForce(Vector2.left * 300f);
                }
                else if (collision.gameObject.transform.position.x < gameObject.transform.position.x)
                {
                    _rb.AddForce(Vector2.right * 300f);
                    _rb.AddForce(Vector2.up * 300f);
                }
                Invoke("TimeOutAfterDamage", 0.1f);
            }
        }
    }
    private void TimeOutAfterDamage()
    {
        _canReset = true;
    }
    private void ResetFromDamage()
    {
        if (_canReset)
        {
            if (_gameCore.IsHurted)
            {
                if (_rb.velocity.y == 0)
                {
                    _spriterend.color = Color.white;
                    _gameCore.CanMoving = true;
                    _gameCore.IsHurted = false;
                    _canReset = false;
                }
            }
        }
    }
}
