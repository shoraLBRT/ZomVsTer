using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeCoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinsWallet.CollectCoin(1);
            Destroy(gameObject);
        }
    }
}
