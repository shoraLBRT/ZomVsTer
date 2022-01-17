using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathLineObj;

    private GameCore _gameCore;
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
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
            Invoke("Restartlvl", 3);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) // падение в пропасть
    {
        if (collision.gameObject == _deathLineObj)
        {
            _gameCore.IsDead = true;
            _gameCore.TakingDamage(100);
            Debug.Log("deathline");
        }
    }
    void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameCore.IsDead = false;
    }
}
