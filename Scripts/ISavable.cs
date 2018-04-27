using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable {
    KeyValuePair<string,string> OnSaveData();
    void OnLoadData(string data);
}
