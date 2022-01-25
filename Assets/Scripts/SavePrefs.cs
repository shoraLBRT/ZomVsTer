using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    private int _lastLvL;
    private int _collectedPoints;
    private float _amountMana;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(750, 0, 125, 50), "Save Your Game"))
            SaveGame();
        if (GUI.Button(new Rect(750, 100, 125, 50), "Load Your Game"))
            LoadGame();
        if (GUI.Button(new Rect(750, 200, 125, 50), "Reset Save Data"))
            ResetData();
    }
    void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", _lastLvL);
        PlayerPrefs.SetInt("SavedFloat", _collectedPoints);
        PlayerPrefs.SetFloat("SavedString", _amountMana);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            _lastLvL = PlayerPrefs.GetInt("SavedInteger");
            _collectedPoints = PlayerPrefs.GetInt("SavedInteger");
            _amountMana = PlayerPrefs.GetFloat("SavedFloat");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    void ResetData()
    {
        PlayerPrefs.DeleteAll();
        _lastLvL = 0;
        _collectedPoints = 0;
        _amountMana = 0.0f;
        Debug.Log("Data reset complete");
    }
}
