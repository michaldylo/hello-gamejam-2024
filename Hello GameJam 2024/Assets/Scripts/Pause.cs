using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _pauseDuration = 2f;
    [SerializeField] private float _pauseCooldown = 6f;
    private bool _isOnCooldown = false;
    [HideInInspector] public bool IsPaused = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!_isOnCooldown)
            {
                StartCoroutine(StartPause());
                StartCoroutine(StartCooldown());
            }
        }
    }

    private IEnumerator StartPause()
    {
        IsPaused = true;
        
        if (gameObject.CompareTag("Player"))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.IsMoving = false;
        }

        float currentGravityScale = _rb.gravityScale;
        _rb.gravityScale = 0f;
        Vector2 currentVelocity = _rb.velocity;
        _rb.velocity = Vector2.zero;
        float currentAngularVelocity = _rb.angularVelocity;
        _rb.angularVelocity = 0f;
        yield return new WaitForSeconds(_pauseDuration);
        _rb.gravityScale = currentGravityScale;
        _rb.velocity = currentVelocity;
        _rb.angularVelocity = currentAngularVelocity;
        
        if (gameObject.CompareTag("Player"))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.IsMoving = true;
        }

        IsPaused = false;
    }

    private IEnumerator StartCooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(_pauseDuration + _pauseCooldown);
        _isOnCooldown = false;
    }
}
