using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool Variable")]
public class BoolVariable : SavableVariable, ISerializationCallbackReceiver
{
    public bool InitialValue;
    [System.NonSerialized]
    public bool RuntimeValue;

    // ISerializationCallbackReceiver
    public void OnAfterDeserialize() { RuntimeValue = InitialValue; }
    public void OnBeforeSerialize() { /*do nothing*/ }

    // ISavable
    public override void OnLoadData(string data)
    {
        RuntimeValue = bool.Parse(data);
        loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.ToString();
    }
}
