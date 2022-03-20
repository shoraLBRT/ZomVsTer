using Internal;
using UnityEngine;

public class OperatingOfZombie : MonoBehaviour, IOperatingState, ICamFolowable
{
    private CameraController _cameraController;
    private ZombieMovement _movementComponent;

    // Отключаемые скиллы
    [SerializeField]
    private GameObject _handThrowingSkill;
    [SerializeField]
    private GameObject _boneSeparationSkill;
    private void Awake()
    {
        _movementComponent = gameObject.GetComponent<ZombieMovement>();

        _cameraController = Locator.GetObject<CameraController>();
    }
    public void Enter()
    {
        CamFolowing(gameObject, 4.5f);
        _movementComponent.enabled = true;
        _handThrowingSkill.SetActive(true);
        _movementComponent.CanMoving = true;
    }
    public void Exit()
    {
        _movementComponent.enabled = false;
        _handThrowingSkill.SetActive(false);
        _movementComponent.CanMoving = false;
    }
    public void Update()
    {

    }
    public void CamFolowing(GameObject targetForFolowing, float camScale)
    {
        _cameraController.ChangeFolowingCam(targetForFolowing);
        _cameraController.CamScale = camScale;
    }
}
