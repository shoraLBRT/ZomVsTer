using Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    private string _textHP;
    private GameCore _gameCore;

    private void Awake()
    {
        Locator.Register<PlayerHud>(this);
    }
    void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        gameObject.GetComponent<Text>().text = $"{_gameCore.PlayerHealth} HP";
        
    }
    public void RefreshHPValue()
    {
        _gameCore.PlayerHealth = (_gameCore.PlayerHealth >= 0 ? _gameCore.PlayerHealth : 0);
        _textHP = _gameCore.PlayerHealth + "HP";
        gameObject.GetComponent<Text>().text = _textHP;
    }

}