using UnityEngine;
using UnityEngine.UI;

public class BoneSeparation : Skills
{
    [SerializeField]
    private GameObject[] _separatedBones;

    [SerializeField]
    private GameObject _playerViewModel;

    [SerializeField]
    private float _cooldown = 10f;
    [SerializeField]
    private Image _coolDownPanel;

    private bool _isCoolDowning;
    private bool _isSeparated;

    private ParticleSystem _explosionEffect;

    private BoxCollider2D _boxCol;
    private Rigidbody2D _rb;
    private void Start()
    {
        _explosionEffect = GetComponent<ParticleSystem>();
        _boxCol = GetComponentInParent<BoxCollider2D>();
        _rb = GetComponentInParent<Rigidbody2D>();

        _isSeparated = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && !_isSeparated && !_isCoolDowning)
            BodySeparate();
        if (Input.GetButtonDown("Fire3") && _isSeparated)
            BodyAssemble();
    }
    private void BodySeparate()
    {
        Vector3 _playerPos = _playerViewModel.transform.position;

        PlayerVisible(false);
        _explosionEffect.Play();
        _isCoolDowning = true;
        _isSeparated = true;

        for (int i = 0; i < _separatedBones.Length; i++)
        {
            Instantiate(_separatedBones[i], new Vector3(Random.Range(_playerPos.x - 1f, _playerPos.x + 1f), Random.Range(_playerPos.y - 0f, _playerPos.y + 2f)), Quaternion.identity);
        }
        StartCoroutine(CoolDowning(_cooldown, _coolDownPanel, resetedCoolDown => _isCoolDowning = resetedCoolDown));
    }
    private void BodyAssemble()
    {
        for (int i = 0; i < _separatedBones.Length; i++)
        {
            Destroy(_separatedBones[i]);
        }
        PlayerVisible(true);
    }
    private void PlayerVisible(bool isVisible)
    {
        _boxCol.isTrigger = !isVisible;
        _playerViewModel.SetActive(isVisible);
        switch (isVisible)
        {
            case true:
                _rb.bodyType = RigidbodyType2D.Dynamic;
                break;
            case false:
                _rb.bodyType = RigidbodyType2D.Static;
                break;
        }
    }
}
