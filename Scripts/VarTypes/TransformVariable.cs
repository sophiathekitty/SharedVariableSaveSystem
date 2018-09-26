using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Transform Variable")]
public class TransformVariable : SavableVariable {
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

        loaded = true;
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

}
