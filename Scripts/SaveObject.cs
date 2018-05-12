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
    public bool hasSave
    {
        get
        {
            return File.Exists(savePath);
        }
    }
    public SavableVariable[] data;
    private SaveDataObject _data;

    public void SaveData()
    {
        _data = new SaveDataObject();

        // run through the data and store it in _data;
        foreach(SavableVariable d in data)
        {
            if (_data.data.ContainsKey(d.name))
                _data.data[d.name] = d.OnSaveData();
            else
                _data.data.Add(d.name, d.OnSaveData());
        }

        // save the data to a binary file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(savePath, FileMode.OpenOrCreate);
        bf.Serialize(file, _data);
        file.Close();

    }
    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(savePath);
            _data = (SaveDataObject)bf.Deserialize(file);
            file.Close();

            // go through data and load values from _data if they exist.
            foreach (SavableVariable d in data)
            {
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
    private class SaveDataObject
    {
        public Dictionary<string, string> data = new Dictionary<string, string>();
    }
}
