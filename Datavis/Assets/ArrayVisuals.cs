using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ArrayVisuals : MonoBehaviour
{
    //  Base
    public float radius = .015f;
    public int[,] myArray = new int[50,50]; //  size
    public int DU; // Distance Unit
    public int scalar; // Scales centers to DU.
    public float offsetX = 0;
    public float offsetY = 0;
    public bool isSorted;
    public bool randomize;
    //  Customization
    [Range(0,49)]
    public int indexr0; // Index rank 0
    [Range(0,49)]
    public int indexr1; // Index rank 1
    public Color color; //TO-DO: Lerp the color values such that the selected variable cycles through all RGB possiblities :D
    public bool setIndexColor;

    //  MOUSE STUFF
    Vector2 mousePos;
    public float closestPosMag;
    public Vector2 closestVec;
    public GameObject mouse;
    
    // Sorts
    public bool binarySort;
    //      Bubble Sort
    public bool bubbleSort;
    public bool bubbleFirstPass = true;
    public float bubbleStartTime;
    public float bubbleFinishTime;
    public float bubbleTimeElapsed;


    //Data Handler xd
    // Should use a hashmap to map each style to a Vector3 position.
    public Dictionary<Vector2, GUIStyle> styleToCoord = new Dictionary<Vector2, GUIStyle>(); // <GUIStyle, Vector3> should be the <T> 2500 styles per frame :)
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        styleToCoord.Clear();
        /*Get the position value for each key, iterate through all 2500 to check which one is the closest
        and then draw a line from the mouse position to that value's 'center'.
        */
        for (int y = 0; y < myArray.GetLength(1); y++)
        {
            for (int x = 0; x < myArray.GetLength(0); x++)
            {

                //2D array stuff (later)

                Gizmos.color = Color.grey;
                Gizmos.DrawLine(new Vector2(x, y + DU), new Vector2(x, y));
                Gizmos.DrawLine(new Vector2(x, y), new Vector2(x + DU, y));
                Gizmos.DrawLine(new Vector2(x + DU, y), new Vector2(x + DU, y + DU));
                Gizmos.DrawLine(new Vector2(x + DU, y + DU), new Vector2(x, y + DU));
                Gizmos.color = Color.red;
                Vector2 center = new Vector2((x + DU + x), ((y + DU) + y)) / 2f; // Center of each square (???)
                center = new Vector2(center.x + offsetX, center.y + offsetY);
                //Debug.Log($"{center} current center should be" + "(" + (currentX + DU + currentX) / 2f + ")");
                GUIStyle style = new GUIStyle();
                if(indexr0 == x && indexr1 == y)
                {
                    style.normal.textColor = color;
                }
                else
                {
                    style.normal.textColor = isSorted switch
                    {
                        true => Color.green,
                        false => Color.red,
                    };
                }
                Handles.Label(center, new GUIContent(myArray[x,y].ToString()), style);
                Gizmos.DrawSphere(center, radius);
                styleToCoord.Add(center, style);
                
            }
        }

        if (randomize)
        {
            for (int y = 0; y < myArray.GetLength(1); y++)
            {
                for (int x = 0; x < myArray.GetLength(0); x++)
                {
                    int newVal = Random.Range(0, 10);
                    myArray[x,y] = (newVal);
                }
            }
        }

        if (binarySort)
        {
            binSort();
        }
        if (bubbleSort)
        {
            if (bubbleFirstPass)
            {
                bubbleStartTime = Time.time;
                bubbleFirstPass = false;
            }
            bubSort();
        }
        //  FOR 8/24/2022
        //  ADD 2D Array Compatibility
        //  Implement Sorting Algorithms and buttons

        //   Always check if the array is sorted. //
        isSorted = checkSorted();
        Gizmos.color = Color.red;
        Vector2[] keys = new Vector2[styleToCoord.Keys.Count];
        styleToCoord.Keys.CopyTo(keys, 0);
        
        for (int x = 0; x < keys.Length; x++)
        {
            Vector2 currVec = keys[x];
            if ((currVec - (Vector2)mouse.transform.position).magnitude < closestPosMag)
            {
                closestPosMag = currVec.magnitude;
                closestVec = currVec;
            }
        }
        Gizmos.DrawLine(closestVec, mouse.transform.position);
        UnityEditorInternal.InternalEditorUtility.RepaintAllViews(); // Repaint the view every frame.
        
    }
#endif

    void Update()
    {
        mousePos = Input.mousePosition;
    }

    void binSort()
    {

    }


    void bubSort() //Should recurse into itself at the end of its cycle
    {
        if (!isSorted)
        {
            for (int y = 0; y < myArray.GetLength(1); y++)
            {
                for (int x = 0; x < myArray.GetLength(0) - 1; x++)
                {
                    if(myArray[x,y] > myArray[x + 1,y])
                    {
                        int hold = myArray[x + 1,y];
                        myArray[x + 1,y] = myArray[x,y];
                        myArray[x,y] = hold;
                    }
                }
            }
        }
        else if (isSorted)
        {
            Debug.Log("Reaches end of bubble sort --------------");
            bubbleFinishTime = Time.time;
            bubbleTimeElapsed = bubbleFinishTime - bubbleStartTime;
            Debug.Log($"Time to sort {bubbleTimeElapsed}");
            bubbleSort = false;
        }
    }
    bool checkSorted()
    {
        for (int y = 0; y < myArray.GetLength(1); y++)
        {
            for (int x = 0; x < myArray.GetLength(0) - 1; x++)
            {
                if (myArray[x,y] > myArray[x + 1,y])
                {
                    //Debug.Log($"{myArray[x]} is val 1 {myArray[x + 1]} is val 2. Should return false");
                    return false;
                }
            }
        }
            return true;
    }
}
