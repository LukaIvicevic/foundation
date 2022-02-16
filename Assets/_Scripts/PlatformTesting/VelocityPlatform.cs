using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityPlatform : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        VelocityMoveForward();
    }

    private void VelocityMoveForward()
    {
        _rb.velocity = transform.forward * 2;
        Invoke("VelocityMoveBackward", 2);
    }

    private void VelocityMoveBackward()
    {
        _rb.velocity = -transform.forward * 2;
        Invoke("VelocityMoveForward", 2);
    }
}
