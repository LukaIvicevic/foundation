using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrapplingGun : MonoBehaviour 
{
    private Quaternion _desiredRotation;
    private float _rotationSpeed = 5f;
    private void Update() {
        if (!GrapplingGun.Instance.IsGrappling()) {
            _desiredRotation = transform.parent.rotation;
        } else {
            _desiredRotation = Quaternion.LookRotation(GrapplingGun.Instance.GetGrapplePoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _desiredRotation, Time.deltaTime * _rotationSpeed);
    }
}