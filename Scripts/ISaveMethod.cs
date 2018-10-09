using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// interface for the basics of save methods.
    /// </summary>
    public interface ISaveMethod
    {
        /// <summary>
        /// display name for save
        /// </summary>
        string SaveName { get; }
        /// <summary>
        /// is there save data?
        /// </summary>
        bool HasSave { get; }
        /// <summary>
        /// Saves the data
        /// </summary>
        void SaveData(Dictionary<int, string> data);
        /// <summary>
        /// Loads the data
        /// </summary>
        Dictionary<int, string> LoadData(Dictionary<int, string> data);
        /// <summary>
        /// Clears the data
        /// </summary>
        void ClearData(Dictionary<int, string> data);
    }
}