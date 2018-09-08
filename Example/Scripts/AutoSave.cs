using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoSave : MonoBehaviour {
    public SaveObject saveObject;
    public UnityEvent DataLoaded = new UnityEvent();
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }
    public void Load()
    {
        saveObject.LoadData();
        DataLoaded.Invoke();
    }
    public void Save()
    {
        saveObject.SaveData();
    }
}
