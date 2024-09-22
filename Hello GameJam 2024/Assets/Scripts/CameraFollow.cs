using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _wheelTransform;

    private void Start()
    {
        _wheelTransform = GameObject.FindWithTag("Player").transform;
    }
    
    void Update()
    {
        transform.position = new Vector3(_wheelTransform.position.x, 0, _wheelTransform.position.z);
    }
}
