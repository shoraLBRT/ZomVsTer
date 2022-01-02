using Internal;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    public int PlayerHealth = 100;

    [HideInInspector]
    public bool IsDead = false;

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