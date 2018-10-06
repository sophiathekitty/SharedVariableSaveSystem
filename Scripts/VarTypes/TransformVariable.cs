using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Save System/Variables/Transform Variable")]
[HelpURL("https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki/TransformVariable")]
public class TransformVariable : SavableVariable, ISerializationCallbackReceiver, IListItemDrawer {
    public Vector3 InitialPosition;
    public Vector3 InitialRotation;
    public Vector3 InitialScale;

    [System.NonSerialized]
    public Vector3 RuntimePosition;
    [System.NonSerialized]
    public Vector3 RuntimeRotation;
    [System.NonSerialized]
    public Vector3 RuntimeScale;

    public Transform RuntimeValue
    {
        set
        {
            RuntimePosition = new Vector3(value.position.x, value.position.y, value.position.z);
            RuntimeRotation = new Vector3(value.localEulerAngles.x, value.localEulerAngles.y, value.localEulerAngles.z);
            RuntimeScale = new Vector3(value.localScale.x, value.localScale.y, value.localScale.z);
        }
    }


    public void OnAfterDeserialize()
    {
        RuntimePosition = new Vector3(InitialPosition.x, InitialPosition.y, InitialPosition.z);
        RuntimeRotation = new Vector3(InitialRotation.x, InitialRotation.y, InitialRotation.z);
        RuntimeScale = new Vector3(InitialScale.x, InitialScale.y, InitialScale.z);
    }

    public void OnBeforeSerialize() { /* do nothing */ }

    public override void OnLoadData(string data)
    {
        string[] values = data.Split('|');
        // postion
        string[] valuesP = values[0].Split(',');
        RuntimePosition = new Vector3(float.Parse(valuesP[0]), float.Parse(valuesP[1]), float.Parse(valuesP[2]));
        // rotation
        string[] valuesR = values[1].Split(',');
        RuntimeRotation = new Vector3(float.Parse(valuesR[0]), float.Parse(valuesR[1]), float.Parse(valuesR[2]));
        // postion
        string[] valuesS = values[2].Split(',');
        RuntimeScale = new Vector3(float.Parse(valuesS[0]), float.Parse(valuesS[1]), float.Parse(valuesS[2]));

        Loaded = true;
    }

    public override string OnSaveData()
    {
        return RuntimePosition.x.ToString() + "," + RuntimePosition.y.ToString() + "," + RuntimePosition.z.ToString() + "|" +
                RuntimeRotation.x.ToString() + "," + RuntimeRotation.y.ToString() + "," + RuntimeRotation.z.ToString() + "|" +
                RuntimeScale.x.ToString() + "," + RuntimeScale.y.ToString() + "," + RuntimeScale.z.ToString();
    }
    public override void OnClearSave()
    {
        OnAfterDeserialize();
    }

    public void OnDrawElement(Rect rect, float line_height)
    {
        GUI.Label(new Rect(rect.x, rect.y, rect.width / 2, line_height - 2), name);
        InitialPosition = EditorGUI.Vector3Field(new Rect(rect.x, rect.y + line_height, rect.width, line_height - 2), "Position", InitialPosition);
        InitialRotation = EditorGUI.Vector3Field(new Rect(rect.x, rect.y + ((line_height + 8) * 2), rect.width, line_height - 2), "Rotation", InitialRotation);
        InitialScale = EditorGUI.Vector3Field(new Rect(rect.x, rect.y + ((line_height + 10) * 3), rect.width, line_height - 2), "Scale", InitialScale);
    }

    public float GetElementHeight(float line_height)
    {
        return (line_height+14) * 4;
    }
}
