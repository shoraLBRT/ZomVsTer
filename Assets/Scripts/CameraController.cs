using UnityEngine;
using Internal;

public class CameraController : MonoBehaviour
{

    public GameObject PlayerObj;

    private GameObject _currentFolowingTarget;

    public GameObject CurrentFolowingTarget { get => _currentFolowingTarget; set => _currentFolowingTarget = value; }

    private void Awake()
    {
        Locator.Register<CameraController>(this);
    }
    private void Start()
    {
        if (CurrentFolowingTarget == null)
            CurrentFolowingTarget = PlayerObj;
    }
    private void LateUpdate()
    {
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
