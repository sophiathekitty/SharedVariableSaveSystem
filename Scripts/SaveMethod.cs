using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class SaveMethod : ScriptableObject, ISaveMethod, IListItemDrawer {
    public abstract DateTime LastSave { get; }
    /// <summary>
    /// The path to the save file
    /// </summary>
    public string SaveFilePath = "";
    /// <summary>
    /// returns true
    /// </summary>
    public abstract bool HasSave { get; }
    public abstract string SavePath { get; }
    public abstract string SaveName { get; }

    /// <summary>
    /// Saves the data
    /// </summary>
    public abstract void SaveData(Dictionary<int,string> data);
    /// <summary>
    /// Loads the data
    /// </summary>
    public abstract Dictionary<int, string> LoadData();
    /// <summary>
    /// Clears the data
    /// </summary>
    public abstract void ClearData();

    public virtual void OnDrawElement(Rect rect, float line_height)
    {
        GUI.Label(new Rect(rect.position, new Vector2(rect.width, line_height-2)), 
            SaveName);
        SaveFilePath = EditorGUI.TextField(
            new Rect(new Vector2(rect.position.x, rect.position.y + line_height), new Vector2(rect.width, line_height-2)),
            "Path",
            SaveFilePath);
    }

    public virtual float GetElementHeight(float line_height)
    {
        return line_height * 2 + 5;
    }

}