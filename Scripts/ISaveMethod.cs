using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveMethod {
    string SaveName { get; }
    bool HasSave { get;  }
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
