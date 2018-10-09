using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SharedVariableSaveSystem;

/// <summary>
/// Scriptable Object for storing Vector3
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Vector3 Variable")]
[HelpURL("https://sophiathekitty.github.io/SharedVariableSaveSystem/html/class_vector3_variable.html")]
public class Vector3Variable : SharedVariable<Vector3>
{
    /// <summary>
    /// applies the initial value to the runtime value
    /// </summary>
    public override void OnAfterDeserialize()
    {
        RuntimeValue = new Vector3(InitialValue.x,InitialValue.y,InitialValue.z);
    }

    /// <summary>
    /// deserializes string into runtime data
    /// </summary>
    /// <param name="data">serialized runtime data</param>
    public override void OnLoadData(string data)
    {
        string[] values = data.Split(',');
        RuntimeValue = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
        Loaded = true;
    }
    /// <summary>
    /// serializes runtime data to a string
    /// </summary>
    /// <returns>serialized runtime data</returns>
    public override string OnSaveData()
    {
        return RuntimeValue.x.ToString()+","+RuntimeValue.y.ToString()+","+RuntimeValue.z.ToString();
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
        InitialValue = EditorGUI.Vector3Field(new Rect(rect.position, new Vector2(rect.width,line_height)),name,InitialValue);
    }
}
