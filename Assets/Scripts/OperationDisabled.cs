using Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationDisabled : IOperatingState, ICamFolowable
{
    private CameraController _cameraController;
    private float _camScale = 0.1f;
    public void CamFolowing(GameObject targetForFolowing, float camScale)
    {
        _cameraController.ChangeFolowingCam(targetForFolowing);
        _cameraController.CamScale = camScale;
    }

    public void Enter()
    {
        _cameraController = Locator.GetObject<CameraController>();
        Debug.Log("не управляю ничем");
        CamFolowing(_cameraController.PlayerObj, _camScale);
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
