﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Vector3 Variable")]
public class Vector3Variable : SharedVariable<Vector3> {


    public override void OnAfterDeserialize()
    {
        RuntimeValue = new Vector3(InitialValue.x,InitialValue.y,InitialValue.z);
    }

    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
        loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString()+","+RuntimeValue.y.ToString()+","+RuntimeValue.z.ToString();
    }
}
