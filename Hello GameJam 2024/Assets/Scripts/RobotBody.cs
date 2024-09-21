using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBody : MonoBehaviour
{
    private Transform _wheelTransform;

    private void Start()
    {
        _wheelTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = _wheelTransform.position + new Vector3(0f, 1.5682f, 0f);
    }
}
