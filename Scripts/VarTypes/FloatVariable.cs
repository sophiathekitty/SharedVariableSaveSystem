using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : SavableVariable, ISerializationCallbackReceiver {
    public float InitialValue;
    public float MinValue = 0;
    public float MaxValue = 1;

    [System.NonSerialized]
    private float _RuntimeValue;
    [System.NonSerialized]
    public float RuntimeMax;
    [System.NonSerialized]
    public float RuntimeMin;

    public float RuntimeValue
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
        RuntimeMax = MaxValue;
        RuntimeMin = MinValue;
        CheckRange();
    }

    public void OnBeforeSerialize()
    {
        CheckRange();
    }

    private void CheckRange()
    {
        if(MinValue > MaxValue)
        {
            float v = MinValue;
            MinValue = MaxValue;
            MaxValue = v;
        }
        if (_RuntimeValue > RuntimeMax)
            _RuntimeValue = RuntimeMax;
        if (_RuntimeValue < RuntimeMin)
            _RuntimeValue = RuntimeMin;
    }

    public override KeyValuePair<string, string> OnSaveData()
    {
        return new KeyValuePair<string, string>(name, RuntimeValue.ToString());
    }

    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
    }
}
