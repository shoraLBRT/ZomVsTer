using Internal;
using UnityEngine;

public class OperatingOfZombie : MonoBehaviour, IOperatingState, ICamFolowable
{
    private CameraController _cameraController;
    private Skills _skills;

    private ZombieMovement _movementComponent;

    // Отключаемые скиллы
    private HandThrowing _handThrowingSkill;
    private BoneSeparation _boneSeparationSkill;
    private void Awake()
    {
        _cameraController = Locator.GetObject<CameraController>();
        _skills = Locator.GetObject<Skills>();


        _movementComponent = gameObject.GetComponent<ZombieMovement>();

        _handThrowingSkill = GetComponentInChildren<HandThrowing>();
        _boneSeparationSkill = GetComponentInChildren<BoneSeparation>();
    }
    public void Enter()
    {
        CamFolowing(gameObject, 4.5f);

        _skills.SetCanBoneSeparation(true);
        _skills.SetCanHandThrowing(true);

        _movementComponent.enabled = true;
    }
    public void Exit()
    {
        _skills.SetCanBoneSeparation(false);
        _skills.SetCanHandThrowing(false);

        _movementComponent.enabled = false;
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
