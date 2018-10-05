using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a float
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Float Variable")]
public class FloatVariable : SharedVariable<float>
{
    /// <summary>
    /// Parses string to float
    /// </summary>
    /// <param name="data">String data to be loaded</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
        Loaded = true;
    }
}
