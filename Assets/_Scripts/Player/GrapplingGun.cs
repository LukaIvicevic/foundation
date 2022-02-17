using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : Singleton<GrapplingGun>
{
    [SerializeField]
    private Vector3 _grapplePoint;
    private SpringJoint _gunSpringJoint;
    private LineRenderer _lineRenderer;
    private float _maxDistance = 100f;
    public Transform cameraTransform;
    public Transform gunExitTransform;
    public Transform playerTransform;
    public LayerMask whatIsGrappleable;

    // TODO: Add "AttemptGrapple()" which would show grapple going out to the raycast point even
    //       if there's no object to grapple onto.
    //       Also, add crosshair to show where grapple would be at?

    private void Start() {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
       if (Input.GetMouseButtonDown(0)) {
           print("Grappling!");
           StartGrapple();
       } else if (Input.GetMouseButtonUp(0)) {
           StopGrapple();
       }
    }

    private void LateUpdate() {
        DrawGrappleRope();
    }

    private void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, _maxDistance, whatIsGrappleable)) {
            _grapplePoint = hit.point;
            _gunSpringJoint = playerTransform.gameObject.AddComponent<SpringJoint>();
            _gunSpringJoint.autoConfigureConnectedAnchor = false;
            _gunSpringJoint.connectedAnchor = _grapplePoint;

            float distanceFromPoint = Vector3.Distance(playerTransform.position, _grapplePoint);
            _gunSpringJoint.maxDistance = distanceFromPoint * 0.8f;
            _gunSpringJoint.minDistance = distanceFromPoint * 0.25f;

            _gunSpringJoint.spring = 4.5f;
            _gunSpringJoint.damper = 7f;
            _gunSpringJoint.massScale = 4.5f;

            _lineRenderer.positionCount = 2;
        }
    }

    private void StopGrapple() {
        _lineRenderer.positionCount = 0;
        Destroy(_gunSpringJoint);
    }

    private void DrawGrappleRope() {
        if (!_gunSpringJoint) return;
        _lineRenderer.SetPosition(0, gunExitTransform.position);
        _lineRenderer.SetPosition(1, _grapplePoint);
    }

    public bool IsGrappling() {
        return _gunSpringJoint != null;
    }

    public Vector3 GetGrapplePoint() {
        return _grapplePoint;
    }
}
