using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OperatingState
{
    public abstract void Enter();
    protected abstract void CamFolowing();
    public abstract void Exit();
    public abstract void Update();
}
