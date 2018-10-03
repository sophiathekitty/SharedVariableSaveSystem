﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class for Scriptable Object variables. Extend this class to create new Savable Shared Variables.
/// </summary>
/// <typeparam name="T">Type of runtime value</typeparam>
public abstract class SharedVariable<T> : SavableVariable, ISerializationCallbackReceiver
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
}
