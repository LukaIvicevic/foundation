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

        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        other.transform.parent = null;
    }
}
