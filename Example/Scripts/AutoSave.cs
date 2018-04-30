using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour {
    public SaveObject saveObject;
    private void OnEnable()
    {
        saveObject.LoadData();
    }
    private void OnDisable()
    {
        saveObject.SaveData();
    }
}
