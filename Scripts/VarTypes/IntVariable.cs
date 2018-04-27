using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : SavableVariable, ISerializationCallbackReceiver {
    public int InitialValue;
    public int MinValue = 0;
    public int MaxValue = 100;

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

    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
    }

    public override KeyValuePair<string, string> OnSaveData()
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
