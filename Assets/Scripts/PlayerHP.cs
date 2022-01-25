using Internal;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private PlayerHud _playerHud;
    private GameCore _gameCore;

    [HideInInspector]
    public int Damage;
    [SerializeField]
    private int _playerHealth = 100;
    public int PlayerHealth
    {
        get { return this._playerHealth; }
        set
        {
            if (value <= 0)
                value = 0;
            this._playerHealth = value;
        }
    }
    private void Awake()
    {
        Locator.Register<PlayerHP>(this);
    }
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _playerHud = Locator.GetObject<PlayerHud>();
    }
    public void TakingDamage(int Damage)
    {
        _gameCore.IsHurted = true;
        PlayerHealth -= Damage;
        _playerHud.RefreshHPValue();
    }
}
