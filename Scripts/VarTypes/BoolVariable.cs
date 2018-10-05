﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a bool
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Bool Variable")]
public class BoolVariable : SharedVariable<bool>
{
    public override void OnLoadData(string data)
    {
        RuntimeValue = bool.Parse(data);
        Loaded = true;
    }
}
