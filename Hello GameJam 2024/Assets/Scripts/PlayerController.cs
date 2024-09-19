using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    private Rigidbody2D _rb;
    private bool _isMoving = true;
    [SerializeField] private float _pauseDuration = 2f;
    [SerializeField] private float _pauseCooldown = 6f;
    private bool _isOnCooldown = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // transform.position += speed * Time.deltaTime * new Vector3(1, 0, 0);

        if (Input.GetButtonDown("Pause"))
        {
            if (!_isOnCooldown)
            {
                StartCoroutine(Pause());
                StartCoroutine(StartCooldown());
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _moveSpeed * Time.fixedDeltaTime * new Vector2(1, 0));
    }

    private IEnumerator Pause()
    {
        _isMoving = false;
        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(_pauseDuration);
        _isMoving = true;
    }

    private IEnumerator StartCooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(_pauseDuration + _pauseCooldown);
        _isOnCooldown = false;
    }
}
