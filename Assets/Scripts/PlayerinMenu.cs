using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerInMenu;
    void Start()
    {
        StartCoroutine(playerRun());
    }
    IEnumerator playerRun ()
    {
        for (int i = 0; i < 100500; i++)
        {
            Instantiate(PlayerInMenu, new Vector3(-13, -2, 7), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}
