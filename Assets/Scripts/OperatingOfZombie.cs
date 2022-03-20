using Internal;
using UnityEngine;

public class OperatingOfZombie : MonoBehaviour, IOperatingState, ICamFolowable
{
    private CameraController _cameraController;
    private Skills _skills;

    private ZombieMovement _movementComponent;
    private void Awake()
    {
        _cameraController = Locator.GetObject<CameraController>();
        _skills = Locator.GetObject<Skills>();

        _movementComponent = gameObject.GetComponent<ZombieMovement>();
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
    public void CamFolowing(GameObject targetForFolowing, float camScale)
    {
        _cameraController.ChangeFolowingCam(targetForFolowing);
        _cameraController.CamScale = camScale;
    }
    void IOperatingState.Update()
    {
    }
}
