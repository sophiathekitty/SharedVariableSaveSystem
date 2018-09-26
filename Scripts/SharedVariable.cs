using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SharedVariable<T> : SavableVariable, ISerializationCallbackReceiver
{
    public T InitialValue;
    public virtual T RuntimeValue { get; set; }
    // ISerializationCallbackReceiver
    public virtual void OnAfterDeserialize() { RuntimeValue = InitialValue; }
    public void OnBeforeSerialize() { /*do nothing*/ }

    public override string OnSaveData()
    {
        return RuntimeValue.ToString();
    }

    public override void OnClearSave()
    {
        OnAfterDeserialize();
    }
}
