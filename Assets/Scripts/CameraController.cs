using Internal;
using UnityEngine;

interface ICamFolowable
{
    void CamFolowing(GameObject targetForFolowing, float camScale);
};
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj;

    private GameObject _currentFolowingTarget;
    public GameObject CurrentFolowingTarget { get => _currentFolowingTarget; set => _currentFolowingTarget = value; }

    private Camera _camera;
    private float _camScale;
    public float CamScale { get => _camScale; set => _camScale = value; }
    public GameObject PlayerObj { get => _playerObj; set => _playerObj = value; }

    private void Awake()
    {
        Locator.Register<CameraController>(this);
    }
    private void Start()
    {
        _camera = gameObject.GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        _camera.orthographicSize = CamScale;
        if (CurrentFolowingTarget != null)
            transform.position = new Vector3(CurrentFolowingTarget.transform.position.x, CurrentFolowingTarget.transform.position.y, -10f);
        CameraLimiter();
    }
    public void ChangeFolowingCam(GameObject newTarget)
    {
        CurrentFolowingTarget = newTarget;
    }
    private void CameraLimiter()
    {
        if (transform.position.x < -2f)
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        if (transform.position.y < 0f)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
