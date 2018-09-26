using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String Variable")]
public class StringVariable : SharedVariable<string>
{
    public override void OnLoadData(string data)
    {
        RuntimeValue = data;
        loaded = true;
    }
}
