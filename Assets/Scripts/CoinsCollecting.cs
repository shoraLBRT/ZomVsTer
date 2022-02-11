using Internal;
using UnityEngine;

public class CoinsCollecting : MonoBehaviour
{
    private CoinsWallet _coinsWallet;

    private void Start()
    {
        _coinsWallet = Locator.GetObject<CoinsWallet>();
    }
    private void OnTriggerEnter2D(Collider2D coin)
    {
        switch (coin.tag)
        {
            case "GoldCoin":
                Destroy(coin.gameObject);
                _coinsWallet.CollectCoin(4);
                break;
            case "SilverCoin":
                Destroy(coin.gameObject);
                _coinsWallet.CollectCoin(2);
                break;
            case "BronzeCoin":
                Destroy(coin.gameObject);
                _coinsWallet.CollectCoin(1);
                break;
        }
    }
}
