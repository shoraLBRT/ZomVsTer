using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
            Destroy(gameObject);
    }
}
