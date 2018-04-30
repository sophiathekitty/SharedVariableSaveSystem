using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Vector3 Variable")]
public class Vector3Variable : SavableVariable, ISerializationCallbackReceiver {
    public Vector3 InitialValue;

    [System.NonSerialized]
    public Vector3 RuntimeValue;


    public void OnAfterDeserialize()
    {
        RuntimeValue = new Vector3(InitialValue.x,InitialValue.y,InitialValue.z);
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
    }

    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString()+","+RuntimeValue.y.ToString()+","+RuntimeValue.z.ToString();
    }
}
