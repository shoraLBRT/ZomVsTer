using Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    // Реализация базового класса для всех врагов еще не закончена.
    protected int EnemyHealth;
    protected abstract void TerrAtacking();
    public abstract void DamageToEnemy(int damage);
}
