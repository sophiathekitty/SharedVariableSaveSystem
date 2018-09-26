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
    public List<SavableVariable> data;
    private SaveDataObject _data;

    public void SaveData()
    {
        _data = new SaveDataObject();

        // run through the data and store it in _data;
        foreach(SavableVariable d in data)
        {
            if (_data.data.ContainsKey(d.GetInstanceID()))
                _data.data[d.GetInstanceID()] = d.OnSaveData();
            else
                _data.data.Add(d.GetInstanceID(), d.OnSaveData());
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
                if (_data.data.ContainsKey(d.GetInstanceID()))
                    d.OnLoadData(_data.data[d.GetInstanceID()]);
            }
        }
    }
    public void clearSaveData()
    {
        // reset data
        foreach (SavableVariable d in data)
            d.OnClearSave();
        // remove saved data...
        if(File.Exists(savePath))
            File.Delete(savePath);

    }

    [System.Serializable]
    private class SaveDataObject
    {
        public Dictionary<int, string> data = new Dictionary<int, string>();
    }
}
