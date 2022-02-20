using Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatingOfPlayer : OperatingState
{
    private CameraController _cameraController;

    public override void Enter()
    {
        _cameraController = Locator.GetObject<CameraController>();
        CamFolowing();
    }
    protected override void CamFolowing()
    {
        _cameraController.ChangeFolowingCam(_cameraController.PlayerObj);
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
