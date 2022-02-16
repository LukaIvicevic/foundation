using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustToggle : MonoBehaviour
{
    public event EventHandler<bool> onThrustToggle;

    [SerializeField]
    private GameObject _thrustToggle;

    private bool _isPlayerInTrigger = false;
    private bool _isThrustActive = false;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {

        var actionKeyPressed = Input.GetKeyDown(KeyCode.E);
        if (_isPlayerInTrigger && actionKeyPressed)
        {
            ToggleThrust();
        }
    }

    private void ToggleThrust()
    {
        _isThrustActive = !_isThrustActive;
        onThrustToggle?.Invoke(this, _isThrustActive);

        if (_isThrustActive)
        {
            _thrustToggle.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            _thrustToggle.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _isPlayerInTrigger = false;
    }
}
