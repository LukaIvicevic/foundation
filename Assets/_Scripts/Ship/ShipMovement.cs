using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private ThrustToggle _thrustToggle;
    [SerializeField]
    private float _thrust = 2000;

    private bool _isThrustActive = false;
    private Rigidbody _rb;

    private void Start()
    {
        _thrustToggle.onThrustToggle += OnThrustToggle;
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleThrust();
    }

    private void OnDestroy()
    {
        _thrustToggle.onThrustToggle -= OnThrustToggle;
    }

    private void HandleThrust()
    {
        if (_isThrustActive)
        {
            _rb.AddForce(transform.forward * _thrust * Time.fixedDeltaTime, ForceMode.Force);
        }
    }

    private void OnThrustToggle(object sender, bool isThrustActive)
    {
        _isThrustActive = isThrustActive;
    }
}
