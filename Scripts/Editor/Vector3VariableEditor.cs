using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Vector3Variable))]
public class Vector3VariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Vector3Variable vector3Variable = (Vector3Variable)target;
        GUILayout.Label("Runtime Value: " + vector3Variable.RuntimeValue.ToString());
    }

}
