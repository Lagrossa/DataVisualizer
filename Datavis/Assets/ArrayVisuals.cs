using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayVisuals : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + 1, transform.position.y));
    }
}
