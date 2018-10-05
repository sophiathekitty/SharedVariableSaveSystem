using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save System/Variables/Attribute Variable")]
public class AttributeVariable : SharedVariable<float>
{
    //public float InitialValue;
    public float InitialMax;
    public float InitialUnavailable;

    public override float RuntimeValue
    {
        get
        {
            if (base.RuntimeValue > RuntimeMax - RuntimeUnavailable)
                return base.RuntimeValue = RuntimeMax - RuntimeUnavailable;
            if (base.RuntimeValue < 0)
                return base.RuntimeValue = 0;
            return base.RuntimeValue;
        }
        set
        {
            if(RuntimeMax == 0)
            {
                base.RuntimeValue = value;
                return;
            }
            if (value > RuntimeMax - RuntimeUnavailable)
                base.RuntimeValue = RuntimeMax - RuntimeUnavailable;
            else if (value < 0)
                base.RuntimeValue = 0;
            else
                base.RuntimeValue = value;
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
            if (RuntimeMax == 0)
                return 0;
            return RuntimeValue / RuntimeMax;
        }
    }

    
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
        Loaded = true;
    }
}
