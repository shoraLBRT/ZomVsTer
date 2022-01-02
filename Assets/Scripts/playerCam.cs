using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public GameObject Player;
    private void LateUpdate()
    {
        transform.position =  new Vector3(Mathf.Lerp(-2f, Player.transform.position.x, Player.transform.position.x), Mathf.Lerp(0, Player.transform.position.y, Player.transform.position.y), -10f);
    }

}
