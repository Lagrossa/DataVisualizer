using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayVisuals : MonoBehaviour
{
    public int[] myArray = { 9,7,4,3,6,5,2,1,8,0 };

    void OnDrawGizmos()
    {
        int width = myArray.Length;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + width, transform.position.y));
    }
}
