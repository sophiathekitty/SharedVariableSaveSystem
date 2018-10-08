using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// Holds a set of references to Savable Variables and Save Methods.
    /// </summary>
    /// <remarks>use multiple save methods to sync save data between multiple locations. list order to prioritize save location when loading.</remarks>
    [CreateAssetMenu(menuName = "Save System/Save Object")]
    [HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/SaveObject")]
    public class SaveObject : ScriptableObject
    {
        /// <summary>
        /// Whether or not a save data exists
        /// </summary>
        public bool HasSave
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
        /// List of different places to save.
        /// </summary>
        /// <seealso cref="SaveMethod"/>
        public List<SaveMethod> SaveLocations;
        /// <summary>
        /// List of the savable variables to save
        /// </summary>
        /// <seealso cref="SavableVariable"/>
        public List<SavableVariable> Data;
        /// <summary>
        /// The data object to be serialized
        /// </summary>
        private Dictionary<int, string> _data
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
        /// Saves the data to all of the save locations
        /// </summary>
        /// <seealso cref="SaveMethod"/>
        public void SaveData()
        {
            foreach (SaveMethod m in SaveLocations)
                if (m != null)
                    m.SaveData(_data);
        }
        /// <summary>
        /// Loads the data from the most recent save location
        /// </summary>
        public void LoadData()
        {
            Dictionary<int, string> _da = new Dictionary<int, string>();
            // find the most recent save
            DateTime lastSave = new DateTime(1900, 1, 1);
            SaveMethod _mR = null;
            foreach (SaveMethod _m in SaveLocations)
            {
                if (_m != null && _m.LastSave >= lastSave)
                    _mR = _m;//_da = _m.LoadData(_data);
            }
            if (_mR != null)
            {
                _da = _mR.LoadData(_data);
                // load data
                foreach (SavableVariable d in Data)
                {
                    if (_da.ContainsKey(d.GetInstanceID()))
                    {
                        d.OnLoadData(_da[d.GetInstanceID()]);
                    }
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
                if (m != null)
                    m.ClearData(_data);
        }
    }
}