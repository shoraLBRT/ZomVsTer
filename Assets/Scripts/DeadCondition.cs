using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathLineObj;

    private GameCore _gameCore;
    private PlayerHP _playerHP;
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _playerHP = Locator.GetObject<PlayerHP>();
    }
    private void Update()
    {
        DeadProcess();
    }
    public void DeadProcess()
    {
        if (_playerHP.PlayerHealth <= 0)
        {
            _gameCore.IsDead = true;
            Invoke("Restartlvl", 3);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) // падение в пропасть
    {
        if (collision.gameObject == _deathLineObj)
        {
            _gameCore.IsDead = true;
            _playerHP.TakingDamage(100);
        }
    }
    void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameCore.IsDead = false;
    }
}
