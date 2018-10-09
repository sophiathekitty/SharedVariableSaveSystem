using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// Base abstract class for a range variable. Adds range limit utils
    /// </summary>
    /// <typeparam name="T">Type of value for the range variable</typeparam>
    public abstract class RangeVariable<T> : SharedVariable<T>
    {
        /// <summary>
        /// Inverts the percentage value of the range. MaxValue becomes 0% of the range
        /// </summary>
        public bool Descending;

        /// <summary>
        /// Lowest possible value
        /// </summary>
        public float MinValue;
        /// <summary>
        /// Largest possible value
        /// </summary>
        public float MaxValue;
        
        /// <summary>
        /// Value used to calculate percentage of range.
        /// </summary>
        /// <remarks>Used to access RuntimeValue for percent calculations</remarks>
        public abstract float FloatValue { get; set; }
        /// <summary>
        /// Where the Runtime value is between the min and max values of the range.
        /// </summary>
        /// <remarks>MinValue is 0% (0.0f) and Max Value is 100% (1.0f)</remarks>
        /// <remarks>If Descending is true MinValue is 100% and MaxValue is 0%</remarks>
        public float Percent
        {
            get
            {
                if (Descending)
                    return (1 - ((FloatValue - MinValue) / (MaxValue - MinValue)));
                return ((FloatValue - MinValue) / (MaxValue - MinValue));
            }
            set
            {
                if (Descending)
                    FloatValue = Mathf.RoundToInt(Mathf.Lerp(MaxValue, MinValue, value));
                else
                    FloatValue = Mathf.RoundToInt(Mathf.Lerp(MinValue, MaxValue, value));
                FitToRange();
            }
        }
        
        /// <summary>
        /// Ensures that the float value is within the min and max of the range.
        /// </summary>
        public void FitToRange()
        {
            if (FloatValue > MaxValue)
                FloatValue = MaxValue;
            if (FloatValue < MinValue)
                FloatValue = MinValue;
        }
    }
}