using Internal;
using UnityEngine;

public class DeathlineTrigger : MonoBehaviour, IAffectToHP
{
    private PlayerHP _playerHP;
    private void Start()
    {
        _playerHP = Locator.GetObject<PlayerHP>();
    }
    void OnTriggerEnter2D(Collider2D collision) // падение в пропасть
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerHP.TakingDamage(_playerHP.PlayerHealth);
        }
    }
}
