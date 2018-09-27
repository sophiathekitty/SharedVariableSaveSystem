using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeVariable<T> : SharedVariable<T>
{
    public T MinValue;
    public T MaxValue;
    public bool Descending;

    public abstract float Percent { get; set; }

    public float GetPercent(float value, float min, float max)
    {
        if (Descending)
            return (1 - ((value - min) / (max - min)));
        return ((value - min) / (max - min));
    }

    public float SetPercent(float percent, float min, float max)
    {
        float value;
        if (Descending)
            value = Mathf.RoundToInt(Mathf.Lerp(max, min, percent));
        else
            value = Mathf.RoundToInt(Mathf.Lerp(min, max, percent));
        return FitToRange(value,min,max);

    }

    public abstract void FitToRange();

    public float FitToRange(float value, float min, float max)
    {
        if (value > max)
            value = max;
        if (value < min)
            value = min;
        return value;
    }

}
