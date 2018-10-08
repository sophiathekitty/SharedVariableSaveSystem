using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharedVariableSaveSystem;

public class AutoSave : MonoBehaviour {
    public SaveObject[] saveObjects;
    private void OnEnable()
    {
        foreach(SaveObject saveObject in saveObjects)
            saveObject.LoadData();
    }
    private void OnDisable()
    {
        foreach (SaveObject saveObject in saveObjects)
            saveObject.SaveData();
    }
}
