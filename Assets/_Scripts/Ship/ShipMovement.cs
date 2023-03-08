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
    private Vector3 _previousLocViaLastThrust = new Vector3(0, 0, 0);

    private void Start()
    {
        _thrustToggle.onThrustToggle += OnThrustToggle;
        _rb = GetComponent<Rigidbody>();
        _previousLocViaLastThrust = transform.position;
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
            _previousLocViaLastThrust = transform.position;
        } else {
            _rb.velocity = Vector3.zero;
            // Debug.Log("Previous last thrust: " + transform.position);
            // transform.position = _previousLocViaLastThrust;  // Lock ship if it's not moving via its own thrust
        }
        _rb.constraints = RigidbodyConstraints.FreezePosition;
        // Debug.Log("Ship velocity: " + _rb.velocity);
    }

    private void OnThrustToggle(object sender, bool isThrustActive)
    {
        _isThrustActive = isThrustActive;
    }
}
