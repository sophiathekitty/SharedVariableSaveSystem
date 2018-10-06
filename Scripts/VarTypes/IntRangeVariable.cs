using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Scriptable Object for storing an int range
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Range/Int Range Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/IntRangeVariable")]
public class IntRangeVariable : RangeVariable<int>
{
    /// <summary>
    /// Converts the int Runtime value to a float for percent calculations
    /// </summary>
    /// <see cref="RangeVariable{T}.Percent"/>
    public override float FloatValue
    {
        get
        {
            return (float)RuntimeValue;
        }

        set
        {
            RuntimeValue = (int)value;
        }
    }
    /// <summary>
    /// Loads data into runtime value
    /// </summary>
    /// <param name="data">String data to be parsed into runtime int</param>
    public override void OnLoadData(string data)
    {
        RuntimeValue = int.Parse(data);
        Loaded = true;
    }

    public override void OnDrawElement(Rect rect, float line_height)
    {
        //base.OnDrawElement(rect, line_height);
        GUI.Label(new Rect(rect.x, rect.y, rect.width / 2, line_height - 2), name);
        if (Descending)
            InitialValue = (int)EditorGUI.Slider(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, line_height - 2), InitialValue, MaxValue, MinValue);
        else
            InitialValue = (int)EditorGUI.Slider(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, line_height - 2), InitialValue, MinValue, MaxValue);
        if (Descending)
        {
            MaxValue = EditorGUI.IntField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), (int)MaxValue);
            MinValue = EditorGUI.IntField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), (int)MinValue);
        }
        else
        {
            MinValue = EditorGUI.IntField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), (int)MinValue);
            MaxValue = EditorGUI.IntField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), (int)MaxValue);

        }
        RuntimeValue = InitialValue;
        EditorGUI.ProgressBar(new Rect(rect.x, rect.y + (line_height * 2), rect.width, line_height + 2), Percent, ToString());
        //GUI.Label(new Rect(rect.x, rect.y + line_height, rect.width, line_height - 2), "Runtime: " + RuntimeValue.ToString() + " | Default: " + InitialValue.ToString());
    }
    public override float GetElementHeight(float line_height)
    {
        return line_height * 3 + 5;
    }

}
