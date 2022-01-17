using Internal;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    private PlayerHud _playerHud;

    public int PlayerHealth = 100; // можно было бы сделать приватным, и доступ к нему только через специальный метод. ХЗ, мб позже сделаю.

    [HideInInspector]
    public bool IsDead;
    [HideInInspector]
    public bool IsHurted;
    [HideInInspector]
    public bool CanMoving;
    [HideInInspector]
    public bool IsGrounded;

    [HideInInspector]
    public int Damage;

    void Awake()
    {
        Locator.Register<GameCore>(this);
    }
    private void Start()
    {
        _playerHud = Locator.GetObject<PlayerHud>();
    }
    public void TakingDamage(int Damage)
    {
        IsHurted = true;
        PlayerHealth -= Damage;
        Debug.Log("takingdamage");
        _playerHud.RefreshHPValue();
        Debug.Log("refreshing HP");
    }
}