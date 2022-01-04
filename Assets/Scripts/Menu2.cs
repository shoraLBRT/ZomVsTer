using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    private Animator _panel2anim;
    public MenuAnimations menuAnimations;
    
    void Start()
    {
        _panel2anim = GetComponent<Animator>();
    }
    public void panel2started()
    {
        _panel2anim.SetInteger("state2panel", 0);
    }
    public void panel2start()
    {
        _panel2anim.SetInteger("state2panel", 1);
    }
    public void panel2return()
    {
        menuAnimations.Panel1return();
        _panel2anim.SetInteger("state2panel", 2);
    }
    public void Start1Level()
    {
        SceneManager.LoadScene(1);
    }
    public void Start2Level()
    {
        SceneManager.LoadScene(2);
    }
}
