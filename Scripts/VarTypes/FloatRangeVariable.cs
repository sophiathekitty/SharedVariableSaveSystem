using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Range Variable")]
public class FloatRangeVariable : SavableVariable, ISerializationCallbackReceiver
{
    public float MinValue;
    public float MaxValue;
    public float InitialValue;
    public bool Descending;

    [System.NonSerialized]
    private float _RuntimeValue;

    public float RuntimeValue
    {
        get
        {
            return _RuntimeValue;
        }
        set
        {
            _RuntimeValue = value;
            FitToRange();
        }
    }
    public float Percent
    {
        get
        {
            if (Descending)
                return (1 - ((_RuntimeValue - MinValue) / (MaxValue - MinValue)));
            return ((_RuntimeValue - MinValue) / (MaxValue - MinValue));
        }
        set
        {
            if (Descending)
                _RuntimeValue = Mathf.Lerp(MaxValue, MinValue, value);
            else
                _RuntimeValue = Mathf.Lerp(MinValue, MaxValue, value);
            FitToRange();
        }
    }
    private void FitToRange()
    {
        if (_RuntimeValue > MaxValue)
            _RuntimeValue = MaxValue;
        if (_RuntimeValue < MinValue)
            _RuntimeValue = MinValue;
    }

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
    public override void OnClearSave()
    {
        OnAfterDeserialize();
    }

}
