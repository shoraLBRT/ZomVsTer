using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private Transform _folowingTarget;

    [SerializeField, Range(0f, 1f)]
    private float _parallaxStrenght = 0.1f;

    [SerializeField]
    private bool _disableVerticalParallax;

    private Vector3 _targetPreviosPosition;
    void Start()
    {
        if (!_folowingTarget)
            _folowingTarget = Camera.main.transform;
        _targetPreviosPosition = _folowingTarget.position;
    }

    void Update()
    {
        var deltaVector3 = _folowingTarget.position - _targetPreviosPosition;
        if (_disableVerticalParallax)
            deltaVector3.y = 0; 
        _targetPreviosPosition = _folowingTarget.position;
        transform.position += deltaVector3 * _parallaxStrenght;
    }
}
