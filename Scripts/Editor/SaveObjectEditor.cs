using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveObject))]
public class SaveObjectEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Clear Save Data"))
        {
            SaveObject so = (SaveObject)target;
            so.clearSaveData();
        }
    }
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        return base.RenderStaticPreview(assetPath, subAssets, width, height);
    }
}
