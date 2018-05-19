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
        SaveObject so = (SaveObject)target;
        if (GUILayout.Button("Clear Save Data"))
        {
            so.clearSaveData();
        }
        if (GUILayout.Button("Find Variables"))
        {
            string[] ass = AssetDatabase.FindAssets("t:SavableVariable");
            foreach(string a in ass)
            {
                if (AssetDatabase.GUIDToAssetPath(a).Contains("/"+so.name+"/"))
                {
                    SavableVariable sv = (SavableVariable)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(a), typeof(SavableVariable));
                    Debug.Log(sv);
                    if (!so.data.Contains(sv))
                        so.data.Add(sv);
                }
            }
        }
    }
}
