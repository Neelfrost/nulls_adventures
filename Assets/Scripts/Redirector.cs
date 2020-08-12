using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirector : MonoBehaviour
{
    private int _facing = 1;

    private void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.forward, 90.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 50.0f);
    }
}
