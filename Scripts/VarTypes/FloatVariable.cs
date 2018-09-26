using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : SharedVariable<float>
{
    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
        loaded = true;
    }
}
