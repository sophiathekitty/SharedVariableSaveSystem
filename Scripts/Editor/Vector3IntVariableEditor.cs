using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Vector3IntVariable))]
public class Vector3IntVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Vector3IntVariable vector3IntVariable = (Vector3IntVariable)target;
        GUILayout.Label("Runtime Value: " + vector3IntVariable.RuntimeValue.ToString());
    }
}
