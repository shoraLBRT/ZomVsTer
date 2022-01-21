using Internal;
using UnityEngine;

public class Terrscript : MonoBehaviour
{
    private GameCore _gameCore;

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

        _animator = GetComponent<Animator>();
        _terspriterend = GetComponent<SpriteRenderer>();
        _isOnA = false;
        _isAttacking = false;
    }
    private void Update()
    {
        switch (_isOnA)
        {
            case true:
                EnemyWalkingToPoint(_pointB);
                _terspriterend.flipX = false;
                break;
            case (false):
                EnemyWalkingToPoint(_pointA);
                _terspriterend.flipX = true;
                break;
        }
        _terStep = _terSpeed * Time.deltaTime;
    }
    void returnToWalking()
    {
        _isAttacking = false;
        _animator.SetInteger("terrstate", 0);
    }
    void EnemyWalkingToPoint(GameObject pointName)
    {
        if (_isAttacking == false)
        {
            _animator.SetInteger("terrstate", 1);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(pointName.transform.position.x, gameObject.transform.position.y), _terStep);
            if (gameObject.transform.position.x == pointName.transform.position.x)
            {
                _isOnA = !_isOnA;
            }
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
