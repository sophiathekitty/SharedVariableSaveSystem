using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SharedVariableSaveSystem;

/// <summary>
/// Scriptable Object for storing a float range
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Range/Float Range Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/FloatRangeVariable")]
public class FloatRangeVariable : RangeVariable<float>
{
    /// <summary>
    /// Alias for Runtime value
    /// </summary>
    /// <remarks>used for Percent</remarks>
    /// <see cref="RangeVariable{T}.Percent"/>
    public override float FloatValue
    {
        get
        {
            return RuntimeValue;
        }

        set
        {
            RuntimeValue = value;
        }
    }

    /// <summary>
    /// Loads Runtime value
    /// </summary>
    /// <param name="data">Data to be loaded into runtime value</param>
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
        GUI.Label(new Rect(rect.x, rect.y, rect.width / 2, line_height - 2), name);
        if(Descending)
            InitialValue = EditorGUI.Slider(new Rect(rect.x+(rect.width/2), rect.y, rect.width / 2, line_height - 2), InitialValue, MaxValue, MinValue);
        else
            InitialValue = EditorGUI.Slider(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, line_height - 2), InitialValue,MinValue,MaxValue);
        if (Descending)
        {
            MaxValue = EditorGUI.FloatField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), MaxValue);
            MinValue = EditorGUI.FloatField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), MinValue);
        }
        else
        {
            MinValue = EditorGUI.FloatField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), MinValue);
            MaxValue = EditorGUI.FloatField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), MaxValue);

        }
        //RuntimeValue = InitialValue;
        EditorGUI.ProgressBar(new Rect(rect.x, rect.y + (line_height * 2), rect.width, line_height + 2),Percent,ToString());
        //GUI.Label(new Rect(rect.x, rect.y + line_height, rect.width, line_height - 2), "Runtime: " + RuntimeValue.ToString() + " | Default: " + InitialValue.ToString());
    }
    /// <summary>
    /// calculates height of element
    /// </summary>
    /// <param name="line_height">used to calculate height</param>
    /// <returns>height of element</returns>
    public override float GetElementHeight(float line_height)
    {
        return line_height*3+5;
    }
}
