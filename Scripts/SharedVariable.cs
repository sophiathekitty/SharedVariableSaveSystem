using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class for Scriptable Object variables. Extend this class to create new Savable Shared Variables.
/// </summary>
/// <typeparam name="T">Type of runtime value</typeparam>
public abstract class SharedVariable<T> : SavableVariable, ISerializationCallbackReceiver, ISaveVariable, IListItemDrawer
{
    /// <summary>
    /// The default value for the variable
    /// </summary>

    public T InitialValue;
    /// <summary>
    /// Runtime value for the variable
    /// </summary>
    public virtual T RuntimeValue { get; set; }

    /// <summary>
    /// display string for the runtime value
    /// </summary>
    public string RuntimeString
    {
        get
        {
            if(RuntimeValue != null)
                return RuntimeValue.ToString();
            return "";
        }
    }

    /// <summary>
    /// display string for the initial value
    /// </summary>
    public string InitialString
    {
        get
        {
            if (InitialValue != null)
                return InitialValue.ToString();
            return "";
        }
    }



    /// <summary>
    /// Applies the default value to the runtime value after deserialization.
    /// </summary>
    /// <remarks>This should happen after changing the default values in the inspector. It will also apply the default value when the game starts.</remarks>
    /// <remarks>Required for ISerializationCallbackReceiver</remarks>
    public virtual void OnAfterDeserialize() { RuntimeValue = InitialValue; }

    /// <summary>
    /// Does nothing.
    /// </summary>
    /// <remarks>Required for ISerializationCallbackReceiver</remarks>
    public void OnBeforeSerialize() { /*do nothing*/ }
    
    /// <summary>
    /// Converts runtime value into a string for SaveObject
    /// </summary>
    /// <returns>String of runtime value</returns>
    /// <seealso cref="SaveObject"/>
    public override string OnSaveData()
    {
        return RuntimeValue.ToString();
    }

    /// <summary>
    /// Resets Runtime value to Initial value
    /// </summary>
    /// <remarks>Calls OnAfterDeserialize</remarks>
    /// <see cref="RuntimeValue"/>
    /// <see cref="InitialValue"/>
    public override void OnClearSave()
    {
        OnAfterDeserialize();
    }

    /// <summary>
    /// display string for the variable
    /// </summary>
    /// <returns>display string</returns>
    public override string ToString()
    {
        if (RuntimeValue != null && InitialValue != null)
            return RuntimeValue.ToString() + "  [" + InitialValue.ToString() + "]";
        return base.ToString();
    }
    /// <summary>
    /// draws a custom inspector of the variable
    /// </summary>
    /// <param name="rect">size of element</param>
    /// <param name="line_height">height of a line</param>
    public virtual void OnDrawElement(Rect rect, float line_height)
    {
        GUI.Label(new Rect(rect.position, new Vector2(rect.width, line_height)), name);
        GUI.Label(new Rect(new Vector2(rect.position.x, rect.position.y + line_height), new Vector2(rect.width, line_height)), ToString());
    }
    /// <summary>
    /// gets the height of the element
    /// </summary>
    /// <param name="line_height">used to calculate height</param>
    /// <returns>height of the element</returns>
    public virtual float GetElementHeight(float line_height)
    {
        return (line_height + 2) * 2;
    }
}
