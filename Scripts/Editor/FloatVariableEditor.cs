using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloatVariable))]
public class FloatVariableEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FloatVariable floatVariable = (FloatVariable)target;
        GUILayout.Label("Runtime Value: "+floatVariable.RuntimeValue.ToString());
    }
}
