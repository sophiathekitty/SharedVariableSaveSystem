using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Range Variable")]
public class IntRangeVariable : SharedVariable<int>, IRangeVariable
{
    public int MinValue;
    public int MaxValue;
    public bool Descending;

    public override int RuntimeValue
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
                return (1 - (((float)base.RuntimeValue - (float)MinValue) / ((float)MaxValue - (float)MinValue)));
            return (((float)base.RuntimeValue - (float)MinValue) / ((float)MaxValue - (float)MinValue));
        }
        set
        {
            if (Descending)
                base.RuntimeValue = Mathf.RoundToInt(Mathf.Lerp((float)MaxValue, (float)MinValue, (float)value));
            else
                base.RuntimeValue = Mathf.RoundToInt(Mathf.Lerp((float)MinValue, (float)MaxValue, (float)value));
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

    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        loaded = true;
    }

    public float GetPercent()
    {
        return Percent;
    }

    public void SetPercent(float percent)
    {
        Percent = percent;
    }
}
