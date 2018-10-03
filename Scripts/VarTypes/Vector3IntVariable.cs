using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a Vector3Int
/// </summary>
[CreateAssetMenu(menuName = "Variables/Vector3Int Variable")]
public class Vector3IntVariable : SharedVariable<Vector3Int>
{
    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3Int(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
        loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString() + "," + RuntimeValue.y.ToString() + "," + RuntimeValue.z.ToString();
    }
}
