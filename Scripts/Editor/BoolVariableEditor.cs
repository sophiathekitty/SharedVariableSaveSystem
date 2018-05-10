using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoolVariable))]
public class BoolVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BoolVariable boolVariable = (BoolVariable)target;
        GUILayout.Label("Runtime Value: " + boolVariable.RuntimeValue.ToString());
    }
}
