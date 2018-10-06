using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Save System/Variables/Attribute Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/AttributeVariable")]
public class AttributeVariable : SharedVariable<float>
{
    //public float InitialValue;
    public float InitialMax;
    public float InitialUnavailable;

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
    [System.NonSerialized]
    public float RuntimeMax;
    [System.NonSerialized]
    public float RuntimeUnavailable;

    public float Percent
    {
        get
        {
            if (RuntimeMax == 0)
                return 0;
            return RuntimeValue / RuntimeMax;
        }
    }

    
    public override string OnSaveData()
    {
        return RuntimeValue.ToString()+","+RuntimeMax.ToString()+","+RuntimeUnavailable.ToString();
    }

    public override void OnLoadData(string data)
    {
        string[] datas = data.Split(',');
        RuntimeValue = float.Parse(datas[0]);
        RuntimeMax = float.Parse(datas[1]);
        RuntimeUnavailable = float.Parse(datas[2]);
        Loaded = true;
    }

    public override void OnAfterDeserialize()
    {
        base.OnAfterDeserialize();
        RuntimeMax = InitialMax;
        RuntimeUnavailable = InitialUnavailable;

    }

    private GUIStyle valueStyle = null;
    private GUIStyle unavailableStyle = null;

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

    public override void OnDrawElement(Rect rect, float line_height)
    {
        InitStyles();
        //base.OnDrawElement(rect, line_height);
        GUI.Label(new Rect(rect.x, rect.y, rect.width / 2, line_height - 2), name);
            InitialValue = EditorGUI.Slider(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, line_height - 2), InitialValue, 0, InitialMax);
            InitialMax = EditorGUI.FloatField(new Rect(rect.x, rect.y + line_height, rect.width / 3, line_height - 2), InitialMax);
            InitialUnavailable = EditorGUI.FloatField(new Rect(rect.x + rect.width / 3, rect.y + line_height, rect.width / 3, line_height - 2), InitialUnavailable);
        OnAfterDeserialize();
        Rect r = new Rect(rect.x, rect.y + line_height * 2, rect.width, line_height+4);
        GUI.Box(r, "");
        GUI.Box(new Rect(r.x + 1, r.y + 1, (r.width - 2) * InitialValue / InitialMax, r.height - 2), InitialValue.ToString(), valueStyle);
        float w = (r.width - 2) * InitialUnavailable / InitialMax;
        GUI.Box(new Rect(r.x + r.width - w, r.y + 1, w, r.height - 2), InitialUnavailable.ToString(), unavailableStyle);
        GUILayout.Space(26);


        //EditorGUI.ProgressBar(new Rect(rect.x, rect.y + (line_height * 2), rect.width, line_height + 2), Percent, ToString());
        //GUI.Label(new Rect(rect.x, rect.y + line_height, rect.width, line_height - 2), "Runtime: " + RuntimeValue.ToString() + " | Default: " + InitialValue.ToString());
    }
    public override float GetElementHeight(float line_height)
    {
        return line_height * 3 + 10;
    }

}
