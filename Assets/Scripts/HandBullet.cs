using Internal;
using UnityEngine;

public class HandBullet : MonoBehaviour
{
    private GameCore _gameCore;

    [SerializeField]
    private int _bulletSpeed = 15;
    [SerializeField]
    private int _bulletLifeTime = 2;

    [SerializeField]
    private GameObject _bonesEffect;

    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();

        if (!_gameCore.IsFliped)
            _bulletSpeed = -_bulletSpeed;
        Destroy(gameObject, _bulletLifeTime);
    }

    private void Update()
    {
        BulletMoving();
    }
    private void BulletMoving()
    {
        gameObject.transform.Translate(-(_bulletSpeed * Time.deltaTime), 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemies>(out Enemies _enemy))
        {
            Instantiate(_bonesEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Damaging(_enemy, 25);
        }
    }
    private void Damaging(Enemies currentEnemy, int damage)
    {
        currentEnemy.DamageToEnemy(25);
    }
}
