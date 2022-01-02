using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCondition : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject deathlineObj;

    private GameCore _gameCore;
    private PlayerHud _playerHud;

    private Animator _animatorComponent;

    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _playerHud = Locator.GetObject<PlayerHud>();
        _animatorComponent = GetComponent<Animator>();
    }
    private void Update()
    {
        DeadProcess();
    }
    public void DeadProcess() // условие и последствия смерти
    {
        if (_gameCore.PlayerHealth <= 0)
        {
            _gameCore.IsDead = true;
            _animatorComponent.SetInteger("state", 10);
            Invoke("Restartlvl", 3);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) // падение в пропасть
    {
        if (collision.gameObject == deathlineObj)
        {
            TakingDamage(100);
            Debug.Log("deathline");
        }
    }
    void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameCore.IsDead = false;
    }
    public void TakingDamage(int Damage)
    {
        _gameCore.PlayerHealth -= Damage;
        RefreshHP();
    }
    public void RefreshHP()
    {
        _playerHud.RefreshHPValue();

        Debug.Log("refreshing HP");
    }
}
