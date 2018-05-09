using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : SavableVariable, ISerializationCallbackReceiver {
    public float InitialValue;

    [System.NonSerialized]
    public float RuntimeValue;


    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override string OnSaveData()
    {
        return RuntimeValue.ToString();
    }

    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
        loaded = true;
    }
}
