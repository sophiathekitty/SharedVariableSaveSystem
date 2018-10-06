using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a Vector3Int
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Vector3Int Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/Vector3IntVariable")]
public class Vector3IntVariable : SharedVariable<Vector3Int>
{
    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3Int(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
        Loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString() + "," + RuntimeValue.y.ToString() + "," + RuntimeValue.z.ToString();
    }
    public override void OnDrawElement(Rect rect, float line_height)
    {
        //base.OnDrawElement(rect, line_height);
        InitialValue = EditorGUI.Vector3IntField(new Rect(rect.position, new Vector2(rect.width, line_height)), name, InitialValue);
    }

}
