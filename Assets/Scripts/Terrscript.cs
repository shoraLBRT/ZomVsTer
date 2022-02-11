using Internal;
using UnityEngine;

public class Terrscript : Enemies, IAffectToHP
{
    private PlayerHP _playerHP;

    [SerializeField]
    private GameObject _playerGameObj;

    [SerializeField]
    private GameObject _silverCoins;

    [SerializeField]
    private GameObject _pointA;
    [SerializeField]
    private GameObject _pointB;

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

        _TerOnA = false;
        _terAttacking = false;
        _terIsDead = false;
    }
    private void Update()
    {
        switch (_TerOnA)
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
    }
    void returnToWalking()
    {
        _terAttacking = false;
        SetAnimationState(AnimationState.idle);
    }
    void EnemyWalkingToPoint(GameObject pointName)
    {
        if (_terAttacking == false && _terIsDead == false)
        {
            SetAnimationState(AnimationState.walk);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(pointName.transform.position.x, gameObject.transform.position.y), _terSpeed * Time.deltaTime);
            if (gameObject.transform.position.x == pointName.transform.position.x)
            {
                _TerOnA = !_TerOnA;
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
    