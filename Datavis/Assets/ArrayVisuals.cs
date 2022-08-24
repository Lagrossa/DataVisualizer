using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayVisuals : MonoBehaviour
{
    public float radius = .055f;
    public int[] myArray = { 9,7,4,3,6,5,2,1,8,0 };

    void OnDrawGizmos()
    {
        int width = myArray.Length;
        int currentX = 0;
        int currentY = 0;

        for(int x = 0; x < myArray.Length; x++)
        {
            Gizmos.DrawLine(new Vector2(currentX, currentY + 1), new Vector2(currentX, currentY));
            Gizmos.DrawLine(new Vector2(currentX, currentY), new Vector2(currentX + 1, currentY));
            Gizmos.DrawLine(new Vector2(currentX + 1, currentY), new Vector2(currentX + 1, currentY + 1));
            Gizmos.DrawLine(new Vector2(currentX + 1, currentY + 1), new Vector2(currentX, currentY + 1));
            Gizmos.DrawSphere(new Vector2(currentX + 1 - currentX, currentY + 1 - currentY), radius);
            currentX++;
        }
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + width, transform.position.y));

    }
}
