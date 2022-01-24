using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMenuDestroy : MonoBehaviour
{
    // Абсолютный кал
    private Animator _animatorComponent;
    void Start()
    {
        _animatorComponent = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(new Vector3(13f, 0, 0) * Time.deltaTime);
        _animatorComponent.SetInteger("state", 1);
        Destroy(gameObject, 6f);
    }
}
