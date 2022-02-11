using Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPtoScene : MonoBehaviour, IAffectToHP
{
    private string _textHP;
    private PlayerHP _playerHP;

    [SerializeField]
    private GameObject _hpOnScene;

    private void Awake()
    {
        Locator.Register<PlayerHPtoScene>(this);
    }
    void Start()
    {
        _playerHP = Locator.GetObject<PlayerHP>();
        _hpOnScene.GetComponent<Text>().text = $"{_playerHP.PlayerHealth} HP";
    }
    public void RefreshHPValue()
    {
        _textHP = _playerHP.PlayerHealth + "HP";
        _hpOnScene.GetComponent<Text>().text = _textHP;
    }
}