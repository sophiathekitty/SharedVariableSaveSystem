using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SharedVariableSaveSystem;
/// <summary>
/// a game attribute. like player health. includes an unavailable value to dynamically reduce the max value. max value can also be changed. like getting more health after leveling up
/// </summary>
[CreateAssetMenu(menuName = "Save System/Variables/Attribute Variable")]
[HelpURL("https://sophiathekitty.github.io/SharedVariableSaveSystem/html/class_attribute_variable.html")]
public class AttributeVariable : SharedVariable<float>
{
    /// <summary>
    /// the initial max value
    /// </summary>
    public float InitialMax;
    /// <summary>
    /// the initial unavailable value
    /// </summary>
    public float InitialUnavailable;

    /// <summary>
    /// the calculated runtime value. runtime value kept within 0 and max minus unavilable.
    /// </summary>
    public override float RuntimeValue
    {
        get
        {
            if (base.RuntimeValue > RuntimeMax - RuntimeUnavailable)
                return base.RuntimeValue = RuntimeMax - RuntimeUnavailable;
            if (base.RuntimeValue < 0)
                return base.RuntimeValue = 0;
            return base.RuntimeValue;
        }
        set
        {
            if(RuntimeMax == 0)
            {
                base.RuntimeValue = value;
                return;
            }
            if (value > RuntimeMax - RuntimeUnavailable)
                base.RuntimeValue = RuntimeMax - RuntimeUnavailable;
            else if (value < 0)
                base.RuntimeValue = 0;
            else
                base.RuntimeValue = value;
        }

    }
    /// <summary>
    /// the runtime max. this can be changed and saved
    /// </summary>
    [System.NonSerialized]
    public float RuntimeMax;
    /// <summary>
    /// the runtime unavailable. this can be changed and saved
    /// </summary>
    [System.NonSerialized]
    public float RuntimeUnavailable;
    /// <summary>
    /// the percent of the value from max
    /// </summary>
    public float Percent
    {
        get
        {
            if (RuntimeMax == 0)
                return 0;
            return RuntimeValue / RuntimeMax;
        }
    }

    /// <summary>
    /// returns a string of the runtime data
    /// </summary>
    /// <returns>serialized runtime data</returns>
    public override string OnSaveData()
    {
        return RuntimeValue.ToString()+","+RuntimeMax.ToString()+","+RuntimeUnavailable.ToString();
    }
    /// <summary>
    /// deserializes string into runtime data
    /// </summary>
    /// <param name="data">serialized runtime data</param>
    public override void OnLoadData(string data)
    {
        string[] datas = data.Split(',');
        RuntimeValue = float.Parse(datas[0]);
        RuntimeMax = float.Parse(datas[1]);
        RuntimeUnavailable = float.Parse(datas[2]);
        Loaded = true;
    }

    /// <summary>
    /// applies the initial data to runtime data
    /// </summary>
    public override void OnAfterDeserialize()
    {
        base.OnAfterDeserialize();
        RuntimeMax = InitialMax;
        RuntimeUnavailable = InitialUnavailable;

    }

    #region bar styles
    /// <summary>
    /// style for displaying the value bar
    /// </summary>
    private GUIStyle valueStyle = null;
    /// <summary>
    /// style for displaying the unavialble bar
    /// </summary>
    private GUIStyle unavailableStyle = null;
    /// <summary>
    /// initialize the styles
    /// </summary>
    private void InitStyles()
    {
        if (valueStyle == null)
        {
            valueStyle = new GUIStyle(GUI.skin.box);
            valueStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1f));
        }
        if (unavailableStyle == null)
        {
            unavailableStyle = new GUIStyle(GUI.skin.box);
            unavailableStyle.normal.background = MakeTex(2, 2, new Color(1f, 0f, 0f, 1f));
        }
    }
    /// <summary>
    /// makes a background text for the bars
    /// </summary>
    /// <param name="width">width</param>
    /// <param name="height">height</param>
    /// <param name="col">color</param>
    /// <returns>background color image</returns>
    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
    #endregion

    /// <summary>
    /// draws the custom inspector for an attribute element
    /// </summary>
    /// <param name="rect">size of element</param>
    /// <param name="line_height">height of a line</param>
    /// <see cref="IListItemDrawer"/>
    public override void OnDrawElement(Rect rect, float line_height)
    {
        InitStyles();
        //base.OnDrawElement(rect, line_height);
        GUI.Label(new Rect(rect.x, rect.y, rect.width / 2, line_height - 2), name);
            InitialValue = EditorGUI.Slider(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, line_height - 2), InitialValue, 0, InitialMax);
            InitialMax = EditorGUI.FloatField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), InitialMax);
            InitialUnavailable = EditorGUI.FloatField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), InitialUnavailable);
        //OnAfterDeserialize();
        Rect r = new Rect(rect.x, rect.y + line_height * 2, rect.width, line_height+4);
        GUI.Box(r, "");
        GUI.Box(new Rect(r.x + 1, r.y + 1, (r.width - 2) * InitialValue / InitialMax, r.height - 2), InitialValue.ToString(), valueStyle);
        float w = (r.width - 2) * InitialUnavailable / InitialMax;
        GUI.Box(new Rect(r.x + r.width - w, r.y + 1, w, r.height - 2), InitialUnavailable.ToString(), unavailableStyle);
        GUILayout.Space(26);
    }
    /// <summary>
    /// the height of the element
    /// </summary>
    /// <param name="line_height">used to calculate height</param>
    /// <returns>height of the element</returns>
    public override float GetElementHeight(float line_height)
    {
        return line_height * 3 + 10;
    }
}
