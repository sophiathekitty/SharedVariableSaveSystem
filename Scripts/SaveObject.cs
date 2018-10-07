using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
/// <summary>
/// Holds a set of references to Savable Variables.
/// </summary>
[CreateAssetMenu(menuName = "Save System/Save Object")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/SaveObject")]
public class SaveObject : ScriptableObject {
    /// <summary>
    /// Whether or not a save file exists
    /// </summary>
    public bool hasSave
    {
        get
        {
            foreach (SaveMethod m in SaveLocations)
                if (m.HasSave)
                    return true;
            return false;
        }
    }
    /// <summary>
    /// Different places to save.
    /// </summary>
    public List<SaveMethod> SaveLocations;
    /// <summary>
    /// List of the savable variables to save
    /// </summary>
    public List<SavableVariable> Data;
    /// <summary>
    /// The data object to be serialized
    /// </summary>
    private Dictionary<int,string> _data
    {
        get
        {
            Dictionary<int, string> _d = new Dictionary<int, string>();
            foreach (SavableVariable d in Data)
            {
                if (_d.ContainsKey(d.GetInstanceID()))
                    _d[d.GetInstanceID()] = d.OnSaveData();
                else
                    _d.Add(d.GetInstanceID(), d.OnSaveData());
            }
            return _d;
        }
    }
    /// <summary>
    /// Saves the data
    /// </summary>
    public void SaveData()
    {
        foreach(SaveMethod m in SaveLocations)
            if(m != null)
                m.SaveData(_data);
    }
    /// <summary>
    /// Loads the data
    /// </summary>
    public void LoadData()
    {
        Dictionary<int, string> _da = new Dictionary<int, string>();
        DateTime lastSave = new DateTime(1900, 1, 1);
        foreach (SaveMethod _m in SaveLocations)
        {
            if(_m != null && _m.LastSave >= lastSave)
                _da = _m.LoadData(_data);
        }
        foreach (SavableVariable d in Data)
        {
            if (_da.ContainsKey(d.GetInstanceID()))
            {
                d.OnLoadData(_da[d.GetInstanceID()]);
            }
        }

    }
    /// <summary>
    /// Reset data
    /// </summary>
    public void ClearSaveData()
    {
        // reset data
        foreach (SavableVariable d in Data)
            d.OnClearSave();
        // remove saved data...
        foreach (SaveMethod m in SaveLocations)
            if(m != null)
                m.ClearData(_data);
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
