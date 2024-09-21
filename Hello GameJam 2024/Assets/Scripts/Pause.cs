using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _pauseDuration = 2f;
    [SerializeField] private float _pauseCooldown = 6f;
    private bool _isOnCooldown = false;

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
        if (gameObject.CompareTag("Player"))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.IsMoving = false;
        }

        _rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(_pauseDuration);
        
        if (gameObject.CompareTag("Player"))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            playerController.IsMoving = true;
        }
    }

    private IEnumerator StartCooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(_pauseDuration + _pauseCooldown);
        _isOnCooldown = false;
    }
}
