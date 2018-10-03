using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing an int range
/// </summary>
[CreateAssetMenu(menuName = "Variables/Int Range Variable")]
public class IntRangeVariable : RangeVariable<int>
{
    /// <summary>
    /// Converts the int Runtime value to a float for percent calculations
    /// </summary>
    /// <see cref="RangeVariable{T}.Percent"/>
    public override float FloatValue
    {
        get
        {
            return (float)RuntimeValue;
        }

        set
        {
            RuntimeValue = (int)value;
        }
    }
    /// <summary>
    /// Loads data into runtime value
    /// </summary>
    /// <param name="data">String data to be parsed into runtime int</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        loaded = true;
    }
}
