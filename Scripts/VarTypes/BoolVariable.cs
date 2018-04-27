using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool Variable")]
public class BoolVariable : ScriptableObject, ISerializationCallbackReceiver, ISavable
{
    public bool InitialValue;
    public bool RuntimeValue;

    // ISerializationCallbackReceiver
    public void OnAfterDeserialize() { RuntimeValue = InitialValue; }
    public void OnBeforeSerialize() { /*do nothing*/ }

    // ISavable
    public void OnLoadData(string data)
    {
        RuntimeValue = bool.Parse(data);
    }

    public KeyValuePair<string, string> OnSaveData()
    {
        return new KeyValuePair<string, string>(name, RuntimeValue.ToString());
    }
}
