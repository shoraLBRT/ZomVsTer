using Internal;
using UnityEngine;
public class GameCore : MonoBehaviour
{
    // Здесь находятся общие переменные, о которых должно быть известно из других классов, и к которым эти самые классы должны иметь доступ.
    [HideInInspector]
    public bool IsDead;
    [HideInInspector]
    public bool IsHurted;
    [HideInInspector]
    public bool CanMoving;
    [HideInInspector]
    public bool IsFliped;
    void Awake()
    {
        Locator.Register<GameCore>(this);
    }
}