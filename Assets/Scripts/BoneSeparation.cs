using Internal;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneSeparation : Skills
{
    private OperationMode _operationMode;

    [SerializeField]
    private GameObject[] _shouldSeparateBones;
    public Queue<GameObject> SeparatedBones;

    [SerializeField]
    private GameObject _playerViewModel;
    [SerializeField]
    private GameObject _playerModel;
    [SerializeField]
    private GameObject _separationPoint;

    [SerializeField]
    private float _cooldown = 10f;
    [SerializeField]
    private Image _coolDownPanel;

    private bool _isCoolDowning;
    private bool _isSeparated;

    private ParticleSystem _explosionEffect;

    private BoxCollider2D _zomBoxCol;
    private Rigidbody2D _zomRigidBody;

    private void Awake()
    {
        Locator.Register<BoneSeparation>(this);
    }
    private void Start()
    {
        _operationMode = Locator.GetObject<OperationMode>();

        _explosionEffect = _separationPoint.GetComponent<ParticleSystem>();
        _zomBoxCol = _playerModel.GetComponent<BoxCollider2D>();
        _zomRigidBody = _playerModel.GetComponent<Rigidbody2D>();

        SeparatedBones = new Queue<GameObject>();
        _isSeparated = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && !_isSeparated && !_isCoolDowning && CanBoneSeparation)
            BodySeparate();
    }
    private void BodySeparate()
    {
        _operationMode.SetStateOperationOfBodyParts();

        Vector3 _playerPos = _playerViewModel.transform.position;
        PlayerVisible(false);
        _isCoolDowning = true;
        _isSeparated = true;

        _explosionEffect.Play();

        foreach (GameObject bone in _shouldSeparateBones)
        {
            bone.transform.position = new Vector3(Random.Range(_playerPos.x - 1f, _playerPos.x + 1f), Random.Range(_playerPos.y - 0f, _playerPos.y + 2f), _playerPos.z);
            bone.SetActive(true);
            SeparatedBones.Enqueue(bone);
        }
        StartCoroutine(CoolDowning(_cooldown, _coolDownPanel, resetedCoolDown => _isCoolDowning = resetedCoolDown));
    }
    public void BodyAssemble()
    {
        _explosionEffect.Play();
        PlayerVisible(true);
        _isSeparated = false;

        foreach (GameObject bone in _shouldSeparateBones)
            bone.SetActive(false);

        _operationMode.SetStateOperationOfZombie();
    }
    private void PlayerVisible(bool isVisible)
    {
        _zomBoxCol.isTrigger = !isVisible;
        _playerViewModel.SetActive(isVisible);
        switch (isVisible)
        {
            case true:
                _zomRigidBody.bodyType = RigidbodyType2D.Dynamic;
                break;
            case false:
                _zomRigidBody.bodyType = RigidbodyType2D.Static;
                break;
        }
    }
}
