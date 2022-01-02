using Internal;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    public int PlayerHealth = 100;

    [HideInInspector]
    public bool IsDead = false;

    [HideInInspector]
    public bool CanMoving = true;
    [HideInInspector]
    public bool IsGrounded = true;

    [HideInInspector]
    public int Damage;
    void Awake()
    {
        Locator.Register<GameCore>(this);
    }
}
interface IDamagable
{
    void TakingDamage(int Damage);
    void RefreshHP();
}