using UnityEngine;
using UnityEngine.UI;
using Internal;

public class BeginEndMessage : MonoBehaviour
{
    // Здесь разделены gameObject'ы и image чтобы можно было отдельно управлять альфой и включением/отключением самого gameObject'a. По сути костыль, займусь позже
    [SerializeField]
    private Image _beginingImage;
    [SerializeField]
    private Image _endingImage;
    [SerializeField]
    private GameObject _endingCanvas;
    [SerializeField]
    private GameObject _beginingCanvas;

    private GameCore _gameCore;
    private void Start()
    {
        _gameCore = Locator.GetObject<GameCore>();
        _beginingCanvas.SetActive(true);
        _beginingImage.CrossFadeAlpha(0, 2f, false);
        Invoke("DisableBegining", 1.5f);
        _endingCanvas.SetActive(false);

    }
    void Update()
    {
        if (_gameCore.IsDead) EndGame();
    }
    public void DisableBegining()
    {
        _beginingCanvas.SetActive(false);
    }
    public void EndGame()
    {
        _endingCanvas.SetActive(true);
        _endingImage.CrossFadeAlpha(0, 2f, false);
    }
}
