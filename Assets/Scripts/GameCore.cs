using Internal;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    public int PlayerHealth = 100; // можно было бы сделать приватным, и доступ к нему только через специальный метод. ХЗ, мб позже сделаю.
    [HideInInspector]
    public bool IsDead = false;
    [HideInInspector]
    public bool CanMoving = true;
    [HideInInspector]
    public bool IsGrounded = true; //пока что ненужный флажок
    [HideInInspector]
    public int Damage;

    private PlayerHud _playerHud;   
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
        PlayerHealth -= Damage;
        Debug.Log("takingdamage");
        _playerHud.RefreshHPValue();
        Debug.Log("refreshing HP");
    }
}