using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[CreateAssetMenu(menuName = "Save Object")]
public class SaveObject : ScriptableObject {
    public string saveFileName = "save.dat";
    public string saveFilePath = "";
    public string savePath
    {
        get
        {
            if (saveFilePath == "")
                return Application.persistentDataPath + saveFileName;
            return saveFilePath + saveFileName;
        }
    }
    public SavableVariable[] data;
    private SaveData _data;

    public void saveData()
    {
        _data = new SaveData();

        // run through the data and store it in _data;
        foreach(SavableVariable d in data)
        {
            KeyValuePair<string, string> kvp = d.OnSaveData();
            Debug.Log("Save: " + kvp.Key + " = " + kvp.Value);
            if (_data.data.ContainsKey(kvp.Key))
                _data.data[kvp.Key] = kvp.Value;
            else
                _data.data.Add(kvp.Key, kvp.Value);
        }

        // save the data to a binary file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(savePath, FileMode.OpenOrCreate);
        bf.Serialize(file, _data);
        file.Close();

    }
    public void loadData()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(savePath);
            _data = (SaveData)bf.Deserialize(file);
            file.Close();

            // go through data and load values from _data if they exist.
            foreach (SavableVariable d in data)
            {
                Debug.Log("Load: " + d.name + " = " + _data.data[d.name]);
                if (_data.data.ContainsKey(d.name))
                    d.OnLoadData(_data.data[d.name]);
            }
        }
    }
    public void clearSaveData()
    {
        // remove saved data...
        if(File.Exists(savePath))
            File.Delete(savePath);

    }

    [System.Serializable]
    private class SaveData
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
    }
}
