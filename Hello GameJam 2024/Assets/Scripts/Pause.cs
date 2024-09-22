using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private int _pauseDuration = 2;
    [SerializeField] private int _pauseCooldown = 5;
    [HideInInspector] public bool IsOnCooldown = false;
    [HideInInspector] public bool IsPaused = false;
    [HideInInspector] public int Cooldown;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Cooldown = _pauseCooldown;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!IsOnCooldown && !IsPaused)
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
        // yield return new WaitForSeconds(_pauseDuration + _pauseCooldown);

        for (int i = _pauseDuration; i > 0; --i)
        {
            Cooldown = i;
            yield return new WaitForSeconds(1f);
        }

        // yield return new WaitForSeconds(_pauseDuration);
        IsOnCooldown = true;

        for (int i = _pauseCooldown; i > 0; --i)
        {
            Cooldown = i;
            yield return new WaitForSeconds(1f);
        }

        IsOnCooldown = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (IsPaused)
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
        }
    }
}
