using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAnimations : MonoBehaviour
{
    private Animator _animator1panel;
    private void Start()
    {
        _animator1panel = GetComponent<Animator>();
    }

    public void Panel1ContinueGame()
    {
        _animator1panel.SetInteger("tapState", 1);
        Invoke(nameof(ContinueGame), 1);
    }
    public void Panel1Levels()
    {
        _animator1panel.SetInteger("tapState", 1);
    }

    public void Panel1return()
    {
        _animator1panel.SetInteger("tapState", 2);
    }
    private void ContinueGame() // временно всегда запускает первый лвл, позже будет продолжать сохранение
    {
        SceneManager.LoadScene(1);
    }
}
