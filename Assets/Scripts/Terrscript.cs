using Internal;
using UnityEngine;

public class Terrscript : Enemies, IAffectToHP
{
    private PlayerHP _playerHP;

    [SerializeField]
    private GameObject _silverCoins;

    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;

    private float _savedPointA;
    private float _savedPointB;

    private bool _TerOnA;
    private bool _terAttacking;
    private bool _terIsDead;

    private Animator _animator;
    private SpriteRenderer _terspriterend;

    private int _terSpeed = 3;
    private int _terHealth = 100;
    public int TerHealth
    {
        get
        {
            return this._terHealth;
        }
        set
        {
            this._terHealth = value;
            if (TerHealth <= 0)
                TerrDying();
        }
    }
    private enum AnimationState { idle, walk, attack, die };
    private AnimationState _currentAnimationState;

    private void Start()
    {
        _playerHP = Locator.GetObject<PlayerHP>();

        _animator = GetComponent<Animator>();
        _terspriterend = GetComponent<SpriteRenderer>();

        _savedPointA = _pointA.position.x;
        _savedPointB = _pointB.position.x;

        _TerOnA = false;
        _terAttacking = false;
        _terIsDead = false;
    }
    private void Update()
    {
        switch (_TerOnA)
        {
            case true:
                EnemyWalkingToPoint(_savedPointB);
                _terspriterend.flipX = false;
                break;
            case (false):
                EnemyWalkingToPoint(_savedPointA);
                _terspriterend.flipX = true;
                break;
        }
    }
    private void returnToWalking()
    {
        _terAttacking = false;
        SetAnimationState(AnimationState.idle);
    }
    private void EnemyWalkingToPoint(float pointName)
    {
        if (_terAttacking == false && _terIsDead == false)
        {
            SetAnimationState(AnimationState.walk);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(pointName, gameObject.transform.position.y), _terSpeed * Time.deltaTime);
            if (gameObject.transform.position.x == pointName)
            {
                _TerOnA = !_TerOnA;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D playercol)
    {
        if (playercol.gameObject.tag == "Player")
        {
            TerrAtacking();
        }
    }
    protected override void TerrAtacking()
    {
        if (!_terIsDead)
        {
            SetAnimationState(AnimationState.attack);
            _terAttacking = true;
            _playerHP.TakingDamage(20);
            Invoke("returnToWalking", 1f);
        }
    }

    public override void DamageToEnemy(int damage)
    {
        TerHealth -= damage;
    }
    protected override void CoinsAfterDie()
    {
        Instantiate(_silverCoins, transform.position, Quaternion.identity);
    }
    private void TerrDying()
    {
        _terIsDead = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        SetAnimationState(AnimationState.die);
        CoinsAfterDie();
        Destroy(gameObject, 8f);
    }
    private void SetAnimationState(AnimationState state)
    {
        _currentAnimationState = state;
        _animator.SetInteger("terrstate", (int)_currentAnimationState);
    }
}
    