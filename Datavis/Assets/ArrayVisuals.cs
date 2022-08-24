using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayVisuals : MonoBehaviour
{
    public float radius = .055f;
    public int[] myArray = { 9,7,4,3,6,5,2,1,8,0 };
    public int DU; // Distance Unit
    public int scalar; // Scales centers to DU.
    void OnDrawGizmos()
    {
        int width = myArray.Length;
        int currentX = 0;
        int currentY = 0;

        for(int x = 0; x < myArray.Length; x++)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(new Vector2(currentX, currentY + DU), new Vector2(currentX, currentY));
            Gizmos.DrawLine(new Vector2(currentX, currentY), new Vector2(currentX + DU, currentY));
            Gizmos.DrawLine(new Vector2(currentX + DU, currentY), new Vector2(currentX + DU, currentY + DU));
            Gizmos.DrawLine(new Vector2(currentX + DU, currentY + DU), new Vector2(currentX, currentY + DU));
            Gizmos.color = Color.red;
            Vector2 center = new Vector2((currentX + DU + currentX), ((currentY + DU) + currentY)) / 2f; // Center of each square (???)
            Debug.Log($"{center} current center should be" + "(" + (currentX + DU + currentX) / 2f + ")");
            Gizmos.DrawSphere(center, radius);
            currentX++;
        }
      

    }
}
