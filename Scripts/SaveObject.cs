using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Object")]
public class SaveObject : ScriptableObject {
    public string saveFileName = "save.dat";

    public IntVariable[] intVars;
    public FloatVariable[] floatVars;
    public BoolVariable[] boolVars;

    public void saveData()
    {

    }
    public void loadData()
    {

    }
}
