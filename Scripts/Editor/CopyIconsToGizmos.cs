using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public class CopyIconsToGizmos {
    static CopyIconsToGizmos()
    {
        if (!File.Exists("Assets/Gizmos/SaveObject Icon.png"))
        {
            Debug.Log("Copy SharedVariableSaveSystem Icons");
            if (!Directory.Exists("Assets/Gizmos"))
                Directory.CreateDirectory("Assets/Gizmos");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/SaveObject Icon.png", "Assets/Gizmos/SaveObject Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/BoolVariable Icon.png", "Assets/Gizmos/BoolVariable Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/IntVariable Icon.png", "Assets/Gizmos/IntVariable Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/FloatVariable Icon.png", "Assets/Gizmos/FloatVariable Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/StringVariable Icon.png", "Assets/Gizmos/StringVariable Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/Vector3Variable Icon.png", "Assets/Gizmos/Vector3Variable Icon.png");
            File.Copy("Assets/SharedVariableSaveSystem/Scripts/Editor/Icons/Vector3IntVariable Icon.png", "Assets/Gizmos/Vector3IntVariable Icon.png");
        }
    }
}
