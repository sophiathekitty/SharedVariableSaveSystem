using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Attribute Variable")]
public class AttributeVariable : SavableVariable, ISerializationCallbackReceiver
{
    public float InitialValue;
    public float InitialMax;
    public float InitialUnavailable;

    [System.NonSerialized]
    private float _value;
    public float RuntimeValue
    {
        get
        {
            if (_value > RuntimeMax - RuntimeUnavailable)
                return _value = RuntimeMax - RuntimeUnavailable;
            if (_value < 0)
                return _value = 0;
            return _value;
        }
        set
        {
            if(RuntimeMax == 0)
            {
                _value = value;
                return;
            }
            if (value > RuntimeMax - RuntimeUnavailable)
                _value = RuntimeMax - RuntimeUnavailable;
            else if (value < 0)
                _value = 0;
            else
                _value = value;
        }

    }
    [System.NonSerialized]
    public float RuntimeMax;
    [System.NonSerialized]
    public float RuntimeUnavailable;

    public float Percent
    {
        get
        {
            return RuntimeValue / RuntimeMax;
        }
    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
        RuntimeMax = InitialMax;
        RuntimeUnavailable = InitialUnavailable;
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override string OnSaveData()
    {
        return RuntimeValue.ToString()+","+RuntimeMax.ToString()+","+RuntimeUnavailable.ToString();
    }

    public override void OnLoadData(string data)
    {
        string[] datas = data.Split(',');
        RuntimeValue = float.Parse(datas[0]);
        RuntimeMax = float.Parse(datas[1]);
        RuntimeUnavailable = float.Parse(datas[2]);
        loaded = true;
    }
}
