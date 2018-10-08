using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a bool
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Bool Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/BoolVariable")]
public class BoolVariable : SharedVariable<bool>
{
    /// <summary>
    /// deserializes string into runtime data
    /// </summary>
    /// <param name="data">serialized runtime data</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = bool.Parse(data);
        Loaded = true;
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
        InitialValue = EditorGUI.Toggle(new Rect(rect.position,new Vector2(rect.width,line_height-2)), name, InitialValue);
        GUI.Label(new Rect(rect.x,rect.y + line_height,rect.width,line_height-2), "Runtime: " + RuntimeValue.ToString() + " | Default: " + InitialValue.ToString());
    }
}
