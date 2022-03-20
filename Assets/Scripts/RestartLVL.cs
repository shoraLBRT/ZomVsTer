using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLVL : MonoBehaviour
{
    private GameCore _gameCore;
    private OperationMode _operationMode;
    private void Awake()
    {
        Locator.Register<RestartLVL>(this);
    }
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _operationMode = Locator.GetObject<OperationMode>();
    }
    public void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameCore.IsDead = false;
        _operationMode.SetStateOperationOfZombie();
    }
}
