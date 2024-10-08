using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    private Rigidbody2D _rb;
    [HideInInspector] public bool IsMoving = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Accelerate());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _moveSpeed * Time.fixedDeltaTime * new Vector2(1, 0));
    }

    private IEnumerator Accelerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _moveSpeed += 0.1f;
        }
    }
}
