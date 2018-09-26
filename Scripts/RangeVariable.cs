using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeVariable<T> : SharedVariable<T>
{
    public T MinValue;
    public T MaxValue;
    public bool Descending;


    public override T RuntimeValue
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


    public virtual float Percent
    {
        get
        {
            if (Descending)
                return (1 - (((float)(object)base.RuntimeValue - (float)(object)MinValue) / ((float)(object)MaxValue - (float)(object)MinValue)));
            return (((float)(object)base.RuntimeValue - (float)(object)MinValue) / ((float)(object)MaxValue - (float)(object)MinValue));
        }
        set
        {
            if (Descending)
                base.RuntimeValue = (T)(object)Mathf.RoundToInt(Mathf.Lerp((float)(object)MaxValue, (float)(object)MinValue, (float)value));
            else
                base.RuntimeValue = (T)(object)Mathf.RoundToInt(Mathf.Lerp((float)(object)MinValue, (float)(object)MaxValue, (float)value));
            FitToRange();
        }
    }


    public virtual void FitToRange()
    {
        if ((float)(object)base.RuntimeValue > (float)(object)MaxValue)
            base.RuntimeValue = MaxValue;
        if ((float)(object)base.RuntimeValue < (float)(object)MinValue)
            base.RuntimeValue = MinValue;
    }

}
