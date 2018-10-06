using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing Vector3
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Vector3 Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/Vector3Variable")]
public class Vector3Variable : SharedVariable<Vector3> {


    public override void OnAfterDeserialize()
    {
        RuntimeValue = new Vector3(InitialValue.x,InitialValue.y,InitialValue.z);
    }

    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
        Loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString()+","+RuntimeValue.y.ToString()+","+RuntimeValue.z.ToString();
    }
    public override void OnDrawElement(Rect rect, float line_height)
    {
        //base.OnDrawElement(rect, line_height);
        InitialValue = EditorGUI.Vector3Field(new Rect(rect.position, new Vector2(rect.width,line_height)),name,InitialValue);
    }
}
