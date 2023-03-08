using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObjectMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Setting " + other.name + "'s transform parent to " + transform.name);
        other.transform.parent.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        other.transform.parent.transform.parent = null;
    }

    private void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (other.name == "Body" && other.transform.parent.name == "Player") {
            other.GetComponent<Rigidbody>().AddForce(Vector3.down, ForceMode.Force);
        }
    }
}
