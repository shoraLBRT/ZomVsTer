using Internal;
using UnityEngine;

public class Terrscript : MonoBehaviour
{
    private GameCore _gameCore;
    private PlayerHud _playerHud;

    [SerializeField]
    private GameObject _playerGameObj;

    [SerializeField]
    private GameObject _pointA;
    [SerializeField]
    private GameObject _pointB;

    private int _terSpeed = 3;
    private float _terStep;
    private bool _isOnA;
    private bool _isAttacking;

    private Animator _animator;
    private SpriteRenderer _terspriterend;

    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _playerHud = Locator.GetObject<PlayerHud>();

        _animator = GetComponent<Animator>();
        _terspriterend = GetComponent<SpriteRenderer>();
        _isOnA = false;
        _isAttacking = false;
        _terSpeed = 3;
    }
    private void Update()
    {
        _terStep = _terSpeed * Time.deltaTime;
        if (_isOnA == true) // если он на точке а, то на надо идти б. Если нет, то на А.
            EnemyWalkingToB();
        else
            EnemyWalkingToA();
    }
    void returnToWalking()
    {
        _isAttacking = false;
        _animator.SetInteger("terrstate", 0);
    }
    void EnemyWalkingToA()
    {
        if (_isAttacking == false)
        {
            _animator.SetInteger("terrstate", 1);
            _terspriterend.flipX = true;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(_pointA.transform.position.x, gameObject.transform.position.y), _terStep);
            if (gameObject.transform.position.x == _pointA.transform.position.x)
                _isOnA = true;
        }
    }
    void EnemyWalkingToB()
    {
        if (_isAttacking == false)
        {
            _animator.SetInteger("terrstate", 1);
            _terspriterend.flipX = false;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(_pointB.transform.position.x, gameObject.transform.position.y), _terStep);
            if (gameObject.transform.position.x == _pointB.transform.position.x)
                _isOnA = false;
        }
    }
    void OnCollisionEnter2D(Collision2D playercol)
    {
        if (playercol.gameObject == _playerGameObj)
        {
            TerrAtacking();
        }
    }
    void TerrAtacking()
    {
        _animator.SetInteger("terrstate", 2);
        _isAttacking = true;
        _gameCore.TakingDamage(20);
        Invoke("returnToWalking", 1f);
    }
}
