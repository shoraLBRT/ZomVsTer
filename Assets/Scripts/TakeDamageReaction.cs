using Internal;
using UnityEngine;

public class TakeDamageReaction : MonoBehaviour
{
    // Пока что непонятки с ребаундом(отскоком) когда и
    [SerializeField]
    private int _rebound;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;
    private Animator _animatorComponent;

    private GameCore _gameCore;
    private void Start()
    {
        _rebound = 500;
        _rb = GetComponent<Rigidbody2D>();
        _spriterend = GetComponent<SpriteRenderer>();
        _animatorComponent = GetComponent<Animator>();
        _gameCore = Locator.GetObject<GameCore>();
    }
    void OnCollisionEnter2D(Collision2D collision) // получение урона
    {
        if (!_gameCore.IsDead)
        {
            if (collision.gameObject.tag == ("Enemy"))
            {
                _rb.AddForce(Vector2.up * _rebound);
                if (_spriterend.flipX == false)
                    _rb.AddForce(Vector2.left * _rebound);
                if (_spriterend.flipX == true)
                    _rb.AddForce(Vector2.right * _rebound);
                _animatorComponent.SetInteger("state", 5);
                _spriterend.color = Color.red;
            }
            else
                _spriterend.color = Color.white;
        }
    }
}
