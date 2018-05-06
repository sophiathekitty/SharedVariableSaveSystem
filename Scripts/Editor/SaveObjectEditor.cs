using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(SaveObject))]
public class SaveObjectEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Clear Save Data"))
        {
            SaveObject so = (SaveObject)target;
            so.clearSaveData();
        }
    }
}
