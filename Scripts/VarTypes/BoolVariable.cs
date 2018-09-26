using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool Variable")]
public class BoolVariable : SharedVariable<bool>
{
    public override void OnLoadData(string data)
    {
        RuntimeValue = bool.Parse(data);
        loaded = true;
    }
}
