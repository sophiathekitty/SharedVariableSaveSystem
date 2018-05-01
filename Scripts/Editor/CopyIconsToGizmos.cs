using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CopyIconsToGizmos {
    static CopyIconsToGizmos()
    {
        FileUtil.CopyFileOrDirectory("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/", "Assets/Gizmos/");
    }
}
