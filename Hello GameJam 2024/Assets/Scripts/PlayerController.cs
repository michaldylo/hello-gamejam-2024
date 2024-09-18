using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // private void Update()
    // {
    //     transform.position += speed * Time.deltaTime * new Vector3(1, 0, 0);
    // }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + speed * Time.fixedDeltaTime * new Vector2(1, 0));
    }
}
