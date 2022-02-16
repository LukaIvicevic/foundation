using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForcePlatform : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        AddForceMoveForward();
    }

    private void AddForceMoveForward()
    {
        _rb.AddForce(transform.forward * 75000);
        Invoke("Reset", 5);
    }

    private void Reset()
    {
        _rb.MovePosition(_startPosition);
        AddForceMoveForward();
    }
}
