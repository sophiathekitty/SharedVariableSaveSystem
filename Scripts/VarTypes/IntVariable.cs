using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : SavableVariable, ISerializationCallbackReceiver {
    public int InitialValue;

    [System.NonSerialized]
    public int RuntimeValue;


    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.ToString();
    }

}
