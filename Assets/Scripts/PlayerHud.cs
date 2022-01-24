using Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    private string _textHP;
    private PlayerHP _playerHP;

    private void Awake()
    {
        Locator.Register<PlayerHud>(this);
    }
    void Start()
    {
        _playerHP = Locator.GetObject<PlayerHP>();
        gameObject.GetComponent<Text>().text = $"{_playerHP.PlayerHealth} HP";
    }
    public void RefreshHPValue()
    {
        _textHP = _playerHP.PlayerHealth + "HP";
        gameObject.GetComponent<Text>().text = _textHP;
    }

}