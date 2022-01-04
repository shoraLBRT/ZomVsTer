using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMenu : MonoBehaviour
{
    // Здесь задумывалось и было реализовано создание на фоне ГГ, чтобы он бегал бесконечно направо, и создавался снова.
    // Абсолютно идиотская реализация, надо сделать фабрику

    [SerializeField]
    private GameObject _playerInMenu;
    void Start()
    {
        StartCoroutine(playerRun());
    }
    IEnumerator playerRun ()
    {
        for (int i = 0; i < 100500; i++)
        {
            Instantiate(_playerInMenu, new Vector3(-13, -2, 7), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}
