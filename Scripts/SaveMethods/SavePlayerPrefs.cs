﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save System/Save Method/PlayerPrefs", fileName = "PlayerPrefs")]
public class SavePlayerPrefs : SaveMethod
{
    public override DateTime LastSave
    {
        get
        {
            if (PlayerPrefs.HasKey(SavePath + "LastSave"))
                return DateTime.Parse(PlayerPrefs.GetString(SavePath + "LastSave"));
            return new DateTime(0, 0, 0);
        }
    }

    public override bool HasSave
    {
        get
        {
            return PlayerPrefs.HasKey(SavePath + "LastSave");
        }
    }

    public override string SavePath
    {
        get
        {
            return SaveFilePath + "_";
        }
    }

    public override string SaveName { get { return SavePath+name; } }

    public override void ClearData(Dictionary<int, string> data)
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey(SavePath + "LastSave");
        foreach (KeyValuePair<int, string> valuePair in data)
        {
            PlayerPrefs.DeleteKey(SavePath + valuePair.Key.ToString());
        }
    }

    public override Dictionary<int, string> LoadData(Dictionary<int, string> data)
    {
        foreach (KeyValuePair<int, string> valuePair in data)
        {
            data[valuePair.Key] = PlayerPrefs.GetString(SavePath + valuePair.Key.ToString());
        }
        return data;
    }

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