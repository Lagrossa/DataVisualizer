using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ArrayVisuals : MonoBehaviour
{
    public float radius = .015f;
    public int[] myArray = new int[10]; //size
    public int DU; // Distance Unit
    public int scalar; // Scales centers to DU.
    public float offsetX = 0;
    public float offsetY = 0;
    public bool isSorted;
    public bool randomize;
    public bool binarySort;
    public bool bubbleSort;
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        int width = myArray.Length;
        int currentX = 0;
        int currentY = 0;
        for(int x = 0; x < myArray.Length; x++)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawLine(new Vector2(currentX, currentY + DU), new Vector2(currentX, currentY));
            Gizmos.DrawLine(new Vector2(currentX, currentY), new Vector2(currentX + DU, currentY));
            Gizmos.DrawLine(new Vector2(currentX + DU, currentY), new Vector2(currentX + DU, currentY + DU));
            Gizmos.DrawLine(new Vector2(currentX + DU, currentY + DU), new Vector2(currentX, currentY + DU));
            Gizmos.color = Color.red;
            Vector2 center = new Vector2((currentX + DU + currentX), ((currentY + DU) + currentY)) / 2f; // Center of each square (???)
            center = new Vector2(center.x + offsetX, center.y + offsetY);
            //Debug.Log($"{center} current center should be" + "(" + (currentX + DU + currentX) / 2f + ")");
            GUIStyle style = new GUIStyle();
            style.normal.textColor = isSorted switch
            {
                true => Color.green,
                false => Color.red,
            };
            Handles.Label(center, new GUIContent(myArray[x].ToString()), style);
            Gizmos.DrawSphere(center, radius);
            currentX++;
        }

        if (randomize)
        {
            for (int x = 0; x < myArray.Length; x++)
            {
                int newVal = Random.Range(0, 10);
                myArray[x] = (newVal);
            }
        }

        if (binarySort)
        {
            binSort();
        }
        if (bubbleSort)
        {
            bubSort();
        }
        //FOR 8/24/2022
        //ADD 2D Array Compatibility
        //Implement Sorting Algorithms and buttons

        //Always check if the array is sorted.
        isSorted = checkSorted();
        UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        
    }
#endif

    void Update()
    {
    }

    void binSort()
    {

    }

    void bubSort()
    {
        float sortTime;
        float startTime = Time.time;
        for(int x = 0; x < myArray.Length-1; x++)
        {
            if (!isSorted)
            {
                if (myArray[x] > myArray[x + 1])
                {
                    int hold = myArray[x + 1];
                    myArray[x + 1] = myArray[x];
                    myArray[x] = hold;
                }
            }
        }
        sortTime = Time.time - startTime;
        Debug.Log($"Time to sort {sortTime}");
    }
    bool checkSorted()
    {
        for (int x = 0; x < myArray.Length - 1; x++)
        {
            if (myArray[x] > myArray[x + 1])
            {
                //Debug.Log($"{myArray[x]} is val 1 {myArray[x + 1]} is val 2. Should return false");
                return false;
            }
        }
            return true;
    }
}
