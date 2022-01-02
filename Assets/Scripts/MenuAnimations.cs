using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAnimations : MonoBehaviour
{
    private Animator animator1panel;
    private void Start()
    {
        animator1panel = GetComponent<Animator>();
    }

    public void Panel1ContinueGame()
    {
        animator1panel.SetInteger("tapState", 1);
        Invoke("ContinueGame", 1);
    }
    public void Panel1Levels()
    {
        animator1panel.SetInteger("tapState", 1);
    }

    public void Panel1return()
    {
        animator1panel.SetInteger("tapState", 2);
    }
    private void ContinueGame() // временно всегда запускает первый лвл, позже будет продолжать сохранение
    {
        SceneManager.LoadScene(1);
    }
}
