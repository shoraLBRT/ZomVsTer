using UnityEngine;
public interface IOperatingState
{
    void Enter();
    void CamFolowing(GameObject targetForFolowing, float camScale);
    void Exit();
    void Update();
}
