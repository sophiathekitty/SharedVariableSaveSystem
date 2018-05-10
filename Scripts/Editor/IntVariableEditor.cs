using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IntVariable))]
public class IntVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        IntVariable intVariable = (IntVariable)target;
        GUILayout.Label("Runtime Value: " + intVariable.RuntimeValue.ToString());
    }
}
