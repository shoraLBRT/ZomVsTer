﻿using UnityEngine;
using UnityEngine.UI;

public class HandThrowing : Skills
{
    [SerializeField]
    private Transform HandPoint;
    [SerializeField]
    private GameObject[] _handBullets;

    private ParticleSystem _bonesEffect;
    [SerializeField]
    private float _manaCost;

    [SerializeField]
    private float _cooldown = 2f;
    [SerializeField]
    private Image _coolDownPanel;

    private bool _isCoolDowning = false;
    private void Start()
    {
        _bonesEffect = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_isCoolDowning)
            ThrowingAHand();
    }
    private void ThrowingAHand()
    {
        _isCoolDowning = true;
        _bonesEffect.Play();
        Instantiate(_handBullets[Random.Range(0, _handBullets.Length)], HandPoint.position, HandPoint.rotation);
        StartCoroutine(CoolDowning(_cooldown, _coolDownPanel, resetedCoolDown => _isCoolDowning = resetedCoolDown));
    }
}