using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(DeckManager))]
public class DeckManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // as an event that return a target. The event is about DeckManager, so return a DeckManager
        DeckManager deckManager = (DeckManager)target;

        if (GUILayout.Button("Draw Next Card")) // create a button and when clicked execute the block
        {
            // searches for the object HandManager instantiated in the scene
            HandManager handManager = FindObjectOfType<HandManager>();
            if (handManager != null)
            {
                deckManager.DrawCard(handManager);
            }
        }

    }

}
#endif

// This class does not need to be assigned to the Unity inspector
// [CustomEditor(typeof(DeckManager))] This is what this association does
// It tells Unity that DeckManagerEditor is a Custom Editor for all objects of type DeckManager