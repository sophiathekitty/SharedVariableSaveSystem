using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SharedVariableSaveSystem;

/// <summary>
/// Scriptable Object for storing a Vector3Int
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Vector3Int Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/Vector3IntVariable")]
public class Vector3IntVariable : SharedVariable<Vector3Int>
{
    /// <summary>
    /// deserializes string into runtime data
    /// </summary>
    /// <param name="data">serialized runtime data</param>
    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3Int(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
        Loaded = true;
    }
    /// <summary>
    /// serializes runtime data into a string
    /// </summary>
    /// <returns>serialized string of runtime data</returns>
    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString() + "," + RuntimeValue.y.ToString() + "," + RuntimeValue.z.ToString();
    }

    /// <summary>
    /// draws the custom inspector for an element
    /// </summary>
    /// <param name="rect">size of element</param>
    /// <param name="line_height">height of a line</param>
    /// <see cref="IListItemDrawer"/>
    public override void OnDrawElement(Rect rect, float line_height)
    {
        //base.OnDrawElement(rect, line_height);
        InitialValue = EditorGUI.Vector3IntField(new Rect(rect.position, new Vector2(rect.width, line_height)), name, InitialValue);
    }
}
