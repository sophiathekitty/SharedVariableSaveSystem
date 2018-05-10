using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TransformVariable))]
public class TransformVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TransformVariable transformVariable = (TransformVariable)target;
        if(Application.isEditor && !Application.isPlaying)
            transformVariable.OnAfterDeserialize();
        GUILayout.Label("Runtime Values:");
        GUILayout.Label("Position: " + transformVariable.RuntimePosition.ToString());
        GUILayout.Label("Rotation: " + transformVariable.RuntimeRotation.ToString());
        GUILayout.Label("Scale: " + transformVariable.RuntimeScale.ToString());
    }
}
