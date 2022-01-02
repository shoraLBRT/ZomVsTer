using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    Animator backanim;
    private void Start()
    {
        backanim = GetComponent<Animator>();
    }
    public void Back()
    {
        Invoke("toMenu", 1);
    }
    private void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
