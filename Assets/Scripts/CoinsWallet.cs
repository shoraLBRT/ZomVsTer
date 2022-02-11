using Internal;
using UnityEngine;
public class CoinsWallet : MonoBehaviour
{
    private static int _coinsInWallet = 0;
    public static int CoinsInWallet
    {
        get
        {
            return _coinsInWallet;
        }
        set
        {
            if (value < 0)
                value = 0;
            _coinsInWallet = value;
        }
    }
    private void Awake()
    {
        Locator.Register<CoinsWallet>(this);
    }
    public void CollectCoin(int value)
    {
        CoinsInWallet = CoinsInWallet + value;
        CoinsOnScene.RefreshCoinsValue();
    }
    public void LossCoins()
    {
        CoinsInWallet -= CoinsInWallet;
        CoinsOnScene.RefreshCoinsValue();
    }
    public void LossCoins(int value)
    {
        CoinsInWallet -= value;
        CoinsOnScene.RefreshCoinsValue();
    }
}
