using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a string
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/String Variable")]
public class StringVariable : SharedVariable<string>
{
    public override void OnLoadData(string data)
    {
        if(data != "")
            RuntimeValue = data;
        Loaded = true;
    }
}
