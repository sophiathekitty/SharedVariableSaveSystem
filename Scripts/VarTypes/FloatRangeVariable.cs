using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a float range
/// </summary>
[CreateAssetMenu(menuName = "Variables/Float Range Variable")]
public class FloatRangeVariable : RangeVariable<float>
{
    /// <summary>
    /// Alias for Runtime value
    /// </summary>
    /// <remarks>used for Percent</remarks>
    /// <see cref="RangeVariable{T}.Percent"/>
    public override float FloatValue
    {
        get
        {
            return RuntimeValue;
        }

        set
        {
            RuntimeValue = value;
        }
    }
    /// <summary>
    /// Loads Runtime value
    /// </summary>
    /// <param name="data">Data to be loaded into runtime value</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
        loaded = true;
    }
}
