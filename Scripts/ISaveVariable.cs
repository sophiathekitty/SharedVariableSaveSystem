using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// interface for a save variable
/// </summary>
public interface ISaveVariable  {
    /// <summary>
    /// Converts runtime value into a string for SaveObject
    /// </summary>
    /// <returns>String of runtime value</returns>
    /// <seealso cref="SaveObject"/>
    string OnSaveData();
    /// <summary>
    /// Resets Runtime value to Initial value
    /// </summary>
    /// <remarks>Calls OnAfterDeserialize</remarks>
    void OnClearSave();
    /// <summary>
    /// Parses string of data into runtime data
    /// </summary>
    /// <param name="data">Data to be loaded</param>
    void OnLoadData(string data);
    string RuntimeString { get; }
    string InitialString { get; }
}
