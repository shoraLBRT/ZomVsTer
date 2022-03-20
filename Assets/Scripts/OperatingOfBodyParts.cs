using Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OperatingOfBodyParts : IOperatingState, ICamFolowable
{
    private Queue<GameObject> _operationPool;
    private GameObject _currentOperationBodyPart;

    private BodyPartMovement _currentBodyPartMovement;

    private CameraController _cameraController;

    private BoneSeparation _boneSeparation;
    public async void Enter()
    {
        _cameraController = Locator.GetObject<CameraController>();
        _boneSeparation = Locator.GetObject<BoneSeparation>();

        await OperationPoolBuilding();
        if (_operationPool.Count != 0)
            NextBodyPart();
    }
    private async Task OperationPoolBuilding()
    {
        _operationPool = new Queue<GameObject>();
        _operationPool = _boneSeparation.SeparatedBones;
        await Task.Delay(100);
    }
    private void NextBodyPart()
    {
        if (_currentOperationBodyPart != null)
            _currentBodyPartMovement.enabled = false;
        if (_operationPool.Count == 0)
        {
            _boneSeparation.BodyAssemble();
            return;
        }
        _currentOperationBodyPart = _operationPool.Dequeue();
        _currentBodyPartMovement = _currentOperationBodyPart.GetComponent<BodyPartMovement>();
        _currentBodyPartMovement.enabled = true;
        CamFolowing(_currentOperationBodyPart, 4f);
        Debug.Log("сейчас управляю" + _currentOperationBodyPart);
    }
    public void Exit()
    {
        _currentBodyPartMovement.enabled = false;
        Debug.Log("вышел из управления телом");
    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            NextBodyPart();
        if (Input.GetButtonDown("Fire3"))
            _boneSeparation.BodyAssemble();
    }

    public void CamFolowing(GameObject targetForFolowing, float camScale)
    {
        _cameraController.ChangeFolowingCam(targetForFolowing);
        _cameraController.CamScale = camScale;
    }
}
