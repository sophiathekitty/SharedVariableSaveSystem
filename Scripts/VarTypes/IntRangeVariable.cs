using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Range Variable")]
public class IntRangeVariable : SavableVariable, ISerializationCallbackReceiver
{
    public int MinValue;
    public int MaxValue;
    public int InitialValue;
    public bool Descending;

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
            FitToRange();
        }
    }
    public float Percent
    {
        get
        {
            if (Descending)
                return (1 - (((float)_RuntimeValue - (float)MinValue) / ((float)MaxValue - (float)MinValue)));
            return (((float)_RuntimeValue - (float)MinValue) / ((float)MaxValue - (float)MinValue));
        }
        set
        {
            if (Descending)
                _RuntimeValue = Mathf.RoundToInt(Mathf.Lerp((float)MaxValue, (float)MinValue, (float)value));
            else
                _RuntimeValue = Mathf.RoundToInt(Mathf.Lerp((float)MinValue, (float)MaxValue, (float)value));
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
        RuntimeValue = int.Parse(data);
        loaded = true;
    }
    public override void OnClearSave()
    {
        OnAfterDeserialize();
    }
}
