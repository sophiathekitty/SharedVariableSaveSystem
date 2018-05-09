using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String Variable")]
public class StringVariable : SavableVariable, ISerializationCallbackReceiver
{
    public string InitialValue;

    [System.NonSerialized]
    public string RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override void OnLoadData(string data)
    {
        RuntimeValue = data;
        loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue;
    }
}
