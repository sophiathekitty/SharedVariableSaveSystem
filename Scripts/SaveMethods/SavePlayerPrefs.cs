using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Saves data using PlayerPrefs
/// </summary>
[CreateAssetMenu(menuName = "Save System/Save Method/PlayerPrefs", fileName = "PlayerPrefs")]
public class SavePlayerPrefs : SaveMethod
{
    /// <summary>
    /// last time the data was saved
    /// </summary>
    /// <see cref="SaveMethod"/>
    public override DateTime LastSave
    {
        get
        {
            if (PlayerPrefs.HasKey(SavePath + "LastSave"))
                return DateTime.Parse(PlayerPrefs.GetString(SavePath + "LastSave"));
            return new DateTime(1900,1,1);
        }
    }

    /// <summary>
    /// does save data exist
    /// </summary>
    /// <see cref="SaveMethod"/>
    public override bool HasSave
    {
        get
        {
            return PlayerPrefs.HasKey(SavePath + "LastSave");
        }
    }

    /// <summary>
    /// prefex for player pref vars
    /// </summary>
    public override string SavePath
    {
        get
        {
            return SaveFilePath + "_";
        }
    }

    /// <summary>
    /// display save name
    /// </summary>
    /// <see cref="SaveMethod"/>
    public override string SaveName { get { return SavePath+name; } }

    /// <summary>
    /// clears the save data
    /// </summary>
    /// <param name="data">data structure to clear</param>
    public override void ClearData(Dictionary<int, string> data)
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey(SavePath + "LastSave");
        foreach (KeyValuePair<int, string> valuePair in data)
        {
            PlayerPrefs.DeleteKey(SavePath + valuePair.Key.ToString());
        }
    }

    /// <summary>
    /// loads data
    /// </summary>
    /// <param name="data">data structure to load</param>
    /// <returns>loaded data</returns>
    public override Dictionary<int, string> LoadData(Dictionary<int, string> data)
    {
        Dictionary<int, string> loaded = new Dictionary<int, string>();
        foreach (KeyValuePair<int, string> valuePair in data)
        {
            loaded[valuePair.Key] = PlayerPrefs.GetString(SavePath + valuePair.Key.ToString());
        }
        return loaded;
    }

    /// <summary>
    /// save data to player prefs
    /// </summary>
    /// <param name="data">data to save</param>
    public override void SaveData(Dictionary<int, string> data)
    {
        PlayerPrefs.SetString(SavePath + "LastSave", DateTime.Now.ToString());
        foreach(KeyValuePair<int,string> valuePair in data)
        {
            PlayerPrefs.SetString(SavePath + valuePair.Key.ToString(), valuePair.Value);
        }
        PlayerPrefs.Save();
    }
}
