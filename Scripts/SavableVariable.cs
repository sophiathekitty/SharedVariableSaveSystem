﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class for savable variables. Used with Save Object to save and load data.
/// </summary>
/// <seealso cref="SaveObject"/>
public abstract class SavableVariable : ScriptableObject {
    /// <summary>
    /// Clear the saved data
    /// </summary>
    public abstract void OnClearSave();
    /// <summary>
    /// Converts runtime data to a string to be saved
    /// </summary>
    /// <returns>String of runtime data</returns>
    public abstract string OnSaveData();
    /// <summary>
    /// Parses string of data into runtime data
    /// </summary>
    /// <param name="data">Data to be loaded</param>
    public abstract void OnLoadData(string data);
    /// <summary>
    /// Set to true if data has been loaded
    /// </summary>
    [System.NonSerialized]
    public bool Loaded = false;
}
