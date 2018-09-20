using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Range Variable")]
public class FloatRangeVariable : RangeVariable<float>
{
/*    public float MinValue;
    public float MaxValue;
    public bool Descending;

    public override float RuntimeValue
    {
        get
        {
            return base.RuntimeValue;
        }
        set
        {
            base.RuntimeValue = value;
            FitToRange();
        }
    }
    public float Percent
    {
        get
        {
            if (Descending)
                return (1 - ((base.RuntimeValue - MinValue) / (MaxValue - MinValue)));
            return ((base.RuntimeValue - MinValue) / (MaxValue - MinValue));
        }
        set
        {
            if (Descending)
                base.RuntimeValue = Mathf.Lerp(MaxValue, MinValue, value);
            else
                base.RuntimeValue = Mathf.Lerp(MinValue, MaxValue, value);
            FitToRange();
        }
    }
    private void FitToRange()
    {
        if (base.RuntimeValue > MaxValue)
            base.RuntimeValue = MaxValue;
        if (base.RuntimeValue < MinValue)
            base.RuntimeValue = MinValue;
    }
    */
    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
        loaded = true;
    }
}
