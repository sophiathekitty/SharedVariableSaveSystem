using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Ojbect for storing an int
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Int Variable")]
public class IntVariable : SharedVariable<int>
{
    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        Loaded = true;
    }
}
