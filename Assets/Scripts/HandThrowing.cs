using UnityEngine;
using UnityEngine.UI;

public class HandThrowing : Skills
{
    [SerializeField]
    private GameObject _handPoint;

    private ParticleSystem _bonesEffect;

    [SerializeField]
    private GameObject[] _handBullets;

    [SerializeField]
    private float _manaCost;

    [SerializeField]
    private float _cooldown = 2f;
    [SerializeField]
    private Image _coolDownPanel;

    private bool _isCoolDowning = false;
    private void Start()
    {
        _bonesEffect = _handPoint.GetComponent<ParticleSystem>();
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
        Instantiate(_handBullets[Random.Range(0, _handBullets.Length)], _handPoint.transform.position, _handPoint.transform.rotation);
        StartCoroutine(CoolDowning(_cooldown, _coolDownPanel, resetedCoolDown => _isCoolDowning = resetedCoolDown));
    }
}