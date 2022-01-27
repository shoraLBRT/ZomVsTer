using UnityEngine;
using UnityEngine.UI;

public class CoinsOnScene : MonoBehaviour
{
    private static string _textCoins;

    [SerializeField]
    private GameObject _coinsOnSceneForInspector;
    private static GameObject _coinsOnScene;

    void Start()
    {
        _coinsOnScene = _coinsOnSceneForInspector;
        _coinsOnScene.GetComponent<Text>().text = $"{CoinsWallet.CoinsInWallet} coins";
    }
    public static void RefreshCoinsValue()
    {
        _textCoins = CoinsWallet.CoinsInWallet + "coins";
        _coinsOnScene.GetComponent<Text>().text = _textCoins;
    }
}