using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver, ISavable {
    public int InitialValue;
    public int MinValue;
    public int MaxValue;

    [System.NonSerialized]
    private int _RuntimeValue;

    public int RuntimeValue
    {
        get
        {
            return _RuntimeValue;
        }
        set
        {
            _RuntimeValue = value;
            CheckRange();
        }
    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {
        CheckRange();
    }

    public void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
    }

    public KeyValuePair<string, string> OnSaveData()
    {
        return new KeyValuePair<string, string>(name, RuntimeValue.ToString());
    }

    private void CheckRange()
    {
        if (MinValue > MaxValue)
        {
            int v = MinValue;
            MinValue = MaxValue;
            MaxValue = v;
        }
        if (RuntimeValue > MaxValue)
            RuntimeValue = MaxValue;
        if (RuntimeValue < MinValue)
            RuntimeValue = MinValue;
    }
}
