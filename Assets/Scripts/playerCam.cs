using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private void LateUpdate()
    {
        transform.position =  new Vector3(Mathf.Lerp(-2f, _player.transform.position.x, _player.transform.position.x), Mathf.Lerp(0, _player.transform.position.y, _player.transform.position.y), -10f);
    }

}
