using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing a float
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Float Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/FloatVariable")]
public class FloatVariable : SharedVariable<float>
{
    /// <summary>
    /// Parses string to float
    /// </summary>
    /// <param name="data">String data to be loaded</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = float.Parse(data);
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
        InitialValue = EditorGUI.FloatField(new Rect(rect.position, new Vector2(rect.width, line_height - 2)), name, InitialValue);
        GUI.Label(new Rect(rect.x, rect.y + line_height, rect.width, line_height - 2), "Runtime: " + RuntimeValue.ToString() + " | Default: " + InitialValue.ToString());
    }
}
