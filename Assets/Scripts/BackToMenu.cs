using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void Back()
    {
        Invoke(nameof(toMenu), 1);
    }
    private void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
