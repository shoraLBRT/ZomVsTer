using UnityEngine;
using UnityEngine.SceneManagement;

public class WinlineTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _winningMessage;

    private void Start()
    {
        _winningMessage.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _winningMessage.SetActive(true);
            Invoke(nameof(toMenu), 3);
        }
    }
    void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
