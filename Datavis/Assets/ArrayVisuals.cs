using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ArrayVisuals : MonoBehaviour
{
    public float radius = .015f;
    public int[] myArray = { 9,7,4,3,6,5,2,1,8,0 };
    public int DU; // Distance Unit
    public int scalar; // Scales centers to DU.
    public float offsetX = 0;
    public float offsetY = 0;
#if UNITY_EDITOR
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
            center = new Vector2(center.x + offsetX, center.y + offsetY);
            //Debug.Log($"{center} current center should be" + "(" + (currentX + DU + currentX) / 2f + ")");
            Rect position = new Rect(center, new Vector2(1,1));
            Handles.Label(center, new GUIContent(myArray[x].ToString()));
            Gizmos.DrawSphere(center, radius);
            currentX++;
        }
      

    }
#endif
}
