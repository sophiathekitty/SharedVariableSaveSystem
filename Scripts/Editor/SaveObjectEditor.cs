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
    private static string icon = "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";

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        return Base64ToTexture(icon);
    }

    private static Texture2D Base64ToTexture(string base64)
    {
        Texture2D t = new Texture2D(1, 1)
        {
            hideFlags = HideFlags.HideAndDontSave
        };
        t.LoadImage(System.Convert.FromBase64String(base64));
        return t;
    }
}
