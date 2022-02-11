using Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    // Реализация базового класса для всех врагов еще не закончена.
    protected int EnemyHealth;

    public abstract void DamageToEnemy(int damage);
    protected abstract void TerrAtacking();
    protected abstract void CoinsAfterDie();
}
