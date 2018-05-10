using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StringVariable))]
public class StringVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StringVariable stringVariable = (StringVariable)target;
        GUILayout.Label("Runtime Value: " + stringVariable.RuntimeValue);
    }
}
