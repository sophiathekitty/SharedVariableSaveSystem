using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Vector3Int Variable")]
public class Vector3IntVariable : SavableVariable, ISerializationCallbackReceiver
{
    public Vector3Int InitialValue;

    [System.NonSerialized]
    public Vector3Int RuntimeValue;


    public void OnAfterDeserialize()
    {
        RuntimeValue = new Vector3Int(InitialValue.x, InitialValue.y, InitialValue.z);
    }

    public void OnBeforeSerialize() { /* do nothing */ }

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
