using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
/// <summary>
/// Holds a set of references to Savable Variables.
/// </summary>
[CreateAssetMenu(menuName = "Save Object")]
public class SaveObject : ScriptableObject {
    /// <summary>
    /// The filename to be used for the save file
    /// </summary>
    public string saveFileName = "save.dat";
    /// <summary>
    /// The path to the save file
    /// </summary>
    public string saveFilePath = "";
    /// <summary>
    /// Combines the save path and filename
    /// </summary>
    public string savePath
    {
        get
        {
            if (saveFilePath == "")
                return Application.persistentDataPath + saveFileName;
            return saveFilePath + saveFileName;
        }
    }
    /// <summary>
    /// Whether or not a save file exists
    /// </summary>
    public bool hasSave
    {
        get
        {
            return File.Exists(savePath);
        }
    }
    /// <summary>
    /// List of the savable variables to save
    /// </summary>
    public List<SavableVariable> data;
    /// <summary>
    /// The data object to be serialized
    /// </summary>
    private SaveDataObject _data;
    /// <summary>
    /// Saves the data
    /// </summary>
    public void SaveData()
    {
        _data = new SaveDataObject();

        // run through the data and store it in _data;
        foreach(SavableVariable d in data)
        {
            if (_data.data.ContainsKey(d.GetInstanceID()))
                _data.data[d.GetInstanceID()] = d.OnSaveData();
            else
                _data.data.Add(d.GetInstanceID(), d.OnSaveData());
        }

        // save the data to a binary file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(savePath, FileMode.OpenOrCreate);
        bf.Serialize(file, _data);
        file.Close();

    }
    /// <summary>
    /// Loads the data
    /// </summary>
    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(savePath);
            _data = (SaveDataObject)bf.Deserialize(file);
            file.Close();

            // go through data and load values from _data if they exist.
            foreach (SavableVariable d in data)
            {
                if (_data.data.ContainsKey(d.GetInstanceID()))
                    d.OnLoadData(_data.data[d.GetInstanceID()]);
            }
        }
    }
    /// <summary>
    /// Reset data
    /// </summary>
    public void clearSaveData()
    {
        // reset data
        foreach (SavableVariable d in data)
            d.OnClearSave();
        // remove saved data...
        if(File.Exists(savePath))
            File.Delete(savePath);

    }
    /// <summary>
    /// Data class for serializing data
    /// </summary>
    [System.Serializable]
    private class SaveDataObject
    {
        /// <summary>
        /// Data to be serialized
        /// </summary>
        public Dictionary<int, string> data = new Dictionary<int, string>();
    }
}
