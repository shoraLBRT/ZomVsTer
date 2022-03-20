using Internal;
using UnityEngine;

interface IAffectToHP { }
public class PlayerHP : MonoBehaviour
{
    private GameCore _gameCore;
    private PlayerHPtoScene _playerHPonScene;
    private CoinsWallet _coinsWallet;
    private OperationMode _operationMode;
    private RestartLVL _restartLVL;

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
        _operationMode = Locator.GetObject<OperationMode>();
        _restartLVL = Locator.GetObject<RestartLVL>();
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
        Invoke(nameof(Restarting), 3);
        _operationMode.SetStateOperationDisabled();
    }
    private void Restarting()
    {
        _restartLVL.Restartlvl();
    }
}
