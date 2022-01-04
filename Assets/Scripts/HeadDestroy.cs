using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDestroy : MonoBehaviour
{
    // говно, надо убирать
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
