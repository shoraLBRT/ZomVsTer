using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsBackground : MonoBehaviour
{
    // Абсолютно идиотская реализация, надо сделать фабрику
    [SerializeField]
    private GameObject[] _heads;

    void Awake()
    {
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        for (int i = 0; i < 100500; i++)
        {
            Vector3 position = new Vector3(Random.Range(-11.0f, 10.0f), 10, -5f);
            Instantiate(_heads[Random.Range(4, 8)], position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
