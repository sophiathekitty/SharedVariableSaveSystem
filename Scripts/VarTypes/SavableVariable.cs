using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavableVariable : ScriptableObject {
    public abstract string OnSaveData();
    public abstract void OnLoadData(string data);
}
