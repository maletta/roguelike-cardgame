using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DrawPileManager))]
public class DrawPileManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // as an event that return a target. The event is about DrawPileManager, so return a DrawPileManager
        DrawPileManager drawPileManager = (DrawPileManager)target;

        if (GUILayout.Button("Draw Next Card")) // create a button and when clicked execute the block
        {
            // searches for the object HandManager instantiated in the scene
            HandManager handManager = FindObjectOfType<HandManager>();
            if (handManager != null)
            {
                drawPileManager.DrawCard(handManager);
            }
        }

    }

}
#endif

// This class does not need to be assigned to the Unity inspector
// [CustomEditor(typeof(DrawPileManager))] This is what this association does
// It tells Unity that DrawPileManager is a Custom Editor for all objects of type DrawPileManager