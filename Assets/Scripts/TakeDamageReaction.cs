using Internal;
using UnityEngine;

public class TakeDamageReaction : MonoBehaviour
{
    private GameCore _gameCore;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriterend;
    private void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
        _spriterend = GetComponentInChildren<SpriteRenderer>();

        _gameCore = Locator.GetObject<GameCore>();
    }
    void OnCollisionEnter2D(Collision2D collision) // получение урона
    {
        if (collision.gameObject.tag == "Enemy" && !_gameCore.IsDead)
        {
            _spriterend.color = Color.red;
            _gameCore.IsHurted = true;
            _gameCore.CanMoving = false;
            if (collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                LeftRebind();
            }
            else 
            {
                RightRebind();
            }
            Invoke(nameof(ResetFromDamage), 0.4f);
        }
    }
    private void LeftRebind()
    {
        _rb.AddForce(Vector2.up * 300f);
        _rb.AddForce(Vector2.left * 300f);
    }
    private void RightRebind()
    {
        _rb.AddForce(Vector2.right * 300f);
        _rb.AddForce(Vector2.up * 300f);
    }
    private void ResetFromDamage()
    {
        _spriterend.color = Color.white;
        _gameCore.CanMoving = true;
        _gameCore.IsHurted = false;
    }
}
