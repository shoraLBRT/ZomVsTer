using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpline : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trumpline" && _rb.velocity.y < 0)
        {
            Debug.Log("triggered");
            _rb.velocity = new Vector2(_rb.velocity.x, 40f);
        }
    }
}
