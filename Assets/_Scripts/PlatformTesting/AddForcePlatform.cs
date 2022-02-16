using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForcePlatform : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startPosition;
    private float _force = 75000f;
    private float _maxVelocity = 3f;

    private bool _isPlayerOnPlatform = false;
    private float _massRatio = 1f;
    private Rigidbody _playerRigidBody;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        // Invoke("Reset", 5);
    }

    private void FixedUpdate()
    {
        AddForceMoveForward();
        AddForceMovePlayer();
    }

    private void AddForceMoveForward()
    {
        if (_rb.velocity.magnitude > _maxVelocity)
        {
            return;
        }

        // Move platform
        _rb.AddForce(transform.forward * _force * Time.fixedDeltaTime);
        print("Platform: " + transform.forward * _force);
    }

    private void AddForceMovePlayer()
    {
        if (!_isPlayerOnPlatform)
        {
            return;
        }

        // Add force to move player with platform
        if (_playerRigidBody.velocity.magnitude < _rb.velocity.magnitude)
        {
            // Magic number that only works for this mass.
            // Does not scale with the ship's force :(
            _playerRigidBody.AddForce(transform.forward * 2000 * Time.fixedDeltaTime);
        }
    }

    private void Reset()
    {
        _rb.MovePosition(_startPosition);
        Invoke("Reset", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _playerRigidBody = other.gameObject.GetComponent<Rigidbody>();

        var platformMass = _rb.mass;
        var playerMass = _playerRigidBody.mass;
        _massRatio = playerMass / platformMass;
        _isPlayerOnPlatform = true;
        print("Player entered platform. Mass Ratio: " + _massRatio);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _isPlayerOnPlatform = false;
        print("Player left platform");
    }
}
