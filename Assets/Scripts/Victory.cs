using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField]
    private GameObject Winline;
    [SerializeField]
    private GameObject Winning;

    private void Start()
    {
        Winning.SetActive(false);

    }
    void OnTriggerEnter2D(Collider2D collision) // победный триггер
    {
        if (collision.gameObject.tag == ("WinLine"))
        {
            Winning.SetActive(true);
            Invoke("toMenu", 3);
        }
    }

    void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
