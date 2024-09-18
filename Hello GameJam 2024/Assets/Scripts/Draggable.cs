using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _selectedObject;
    private Vector2 _offset;
    private Vector2 _mousePosition;
    [SerializeField] private float _maxSpeed = 10.0f;
    private Vector2 _mouseForce;
    private Vector2 _lastPosition = Vector2.zero;

    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_selectedObject)
        {
            _mouseForce = (_mousePosition - _lastPosition) / Time.deltaTime;
            _mouseForce = Vector2.ClampMagnitude(_mouseForce, _maxSpeed);
            _lastPosition = _mousePosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(_mousePosition);

            if (targetObject)
            {
                _selectedObject = targetObject.GetComponent<Rigidbody2D>();
                _offset = _selectedObject.position - _mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {

            _selectedObject.velocity = Vector2.zero;
            _selectedObject.AddForce(_mouseForce, ForceMode2D.Impulse);
            _selectedObject = null;
        }
    }

    private void FixedUpdate()
    {
        if (_selectedObject)
        {
            _selectedObject.MovePosition(_mousePosition + _offset);
        }
    }
}
