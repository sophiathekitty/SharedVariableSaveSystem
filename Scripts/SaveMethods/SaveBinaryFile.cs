using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Save System/Save Method/BinaryFile", fileName = "Save")]
public class SaveBinaryFile : SaveMethod
{
    /// <summary>
    /// The filename to be used for the save file
    /// </summary>
    public string SaveExtension = "dat";
    /// <summary>
    /// Combines the save path and filename
    /// </summary>
    public override string SavePath
    {
        get
        {
            if (SaveFilePath == "")
                return Application.persistentDataPath + name + "." + SaveExtension;
            return SaveFilePath + name + SaveExtension;
        }
    }

    public override bool HasSave
    {
        get
        {
            return File.Exists(SavePath);
        }
    }
    public override DateTime LastSave
    {
        get
        {
            if (HasSave)
                return File.GetLastAccessTime(SavePath);
            return new DateTime(0,0,0);
        }

    }

    public override string SaveName
    {
        get
        {
            return "~/"+ name + "." + SaveExtension;
        }
    }

    public override Dictionary<int, string> LoadData()
    {
        Dictionary<int, string> data = new Dictionary<int, string>();
        if (File.Exists(SavePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(SavePath);
            data = (Dictionary<int, string>)bf.Deserialize(file);
            file.Close();
        }
        return data;
    }

    public override void SaveData(Dictionary<int, string> data)
    {
        // save the data to a binary file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(SavePath, FileMode.OpenOrCreate);
        bf.Serialize(file, data);
        file.Close();
    }

    public override void ClearData()
    {
        // remove saved data...
        if (File.Exists(SavePath))
            File.Delete(SavePath);
    }

    public override float GetElementHeight(float line_height)
    {
        return base.GetElementHeight(line_height) + line_height;
    }
    public override void OnDrawElement(Rect rect, float line_height)
    {
        base.OnDrawElement(rect, line_height);
        SaveExtension = EditorGUI.TextField(
            new Rect(new Vector2(rect.position.x, rect.position.y + (line_height*2)), new Vector2(rect.width, line_height-2)),
            "Extension",
            SaveExtension);
    }

}
