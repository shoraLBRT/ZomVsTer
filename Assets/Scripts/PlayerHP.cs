using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

interface IAffectToHP { }
public class PlayerHP : MonoBehaviour
{
    private PlayerHPtoScene _playerHPonScene;
    private GameCore _gameCore;
    private CoinsWallet _coinsWallet;

    [HideInInspector]
    public int Damage;

    [SerializeField]
    private int _playerHealth = 100;
    public int PlayerHealth
    {
        get { return _playerHealth; }
        set
        {
            if (value <= 0)
            {
                value = 0;
                DeathProcess();
            }

            _playerHealth = value;
        }
    }
    private void Awake()
    {
        Locator.Register<PlayerHP>(this);
    }
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _playerHPonScene = Locator.GetObject<PlayerHPtoScene>();
        _coinsWallet = Locator.GetObject<CoinsWallet>();
    }
    public void TakingDamage(int Damage)
    {
        _coinsWallet.LossCoins(1);
        PlayerHealth -= Damage;
        _playerHPonScene.RefreshHPValue();
    }
    private void DeathProcess()
    {
        _coinsWallet.LossCoins();
        _gameCore.IsDead = true;
        Invoke("Restartlvl", 3);
    }
    private void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameCore.IsDead = false;
    }

}
