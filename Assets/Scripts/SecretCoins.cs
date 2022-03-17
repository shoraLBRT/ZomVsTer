using UnityEngine;

public class SecretCoins : MonoBehaviour
{
    [SerializeField]
    private GameObject _goldCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Invoke("Instantiating", 0.5f);
    }
    private void Instantiating()
    {
        Instantiate(_goldCoin, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
