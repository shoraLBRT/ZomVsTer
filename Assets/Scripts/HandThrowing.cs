using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandThrowing : MonoBehaviour
{
    [SerializeField]
    private Transform HandPoint;
    [SerializeField]
    private GameObject[] _handBullets;
    [SerializeField]
    private GameObject _bonesEffect;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            ThrowingAHand();
    }
    private void ThrowingAHand()
    {
        Instantiate(_bonesEffect, transform.position, Quaternion.identity);
        Instantiate(_handBullets[Random.Range(0, _handBullets.Length)], HandPoint.position, HandPoint.rotation);
    }
}