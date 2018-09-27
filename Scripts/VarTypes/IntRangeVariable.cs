using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Range Variable")]
public class IntRangeVariable : RangeVariable<int>
{
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

    public override float Percent
    {
        get
        {
            return GetPercent(RuntimeValue, MinValue, MaxValue);
        }

        set
        {
            base.RuntimeValue = (int)SetPercent(value, MinValue, MaxValue);
        }
    }

    public override void FitToRange()
    {
        base.RuntimeValue = (int)FitToRange(RuntimeValue, MinValue, MaxValue);
    }

    /*    public int MinValue;
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
   */
    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        loaded = true;
    }
}
