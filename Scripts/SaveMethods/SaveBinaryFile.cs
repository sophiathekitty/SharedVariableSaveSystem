using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
namespace SharedVariableSaveSystem
{ 
    /// <summary>
    /// Saves a binary file to the local disk.
    /// </summary>
    [CreateAssetMenu(menuName = "Save System/Save Method/BinaryFile", fileName = "Save")]
    [HelpURL("https://sophiathekitty.github.io/SharedVariableSaveSystem/html/class_shared_variable_save_system_1_1_save_binary_file.html")]
    public class SaveBinaryFile : SaveMethod
    {
        /// <summary>
        /// The file extension to be used for the save file
        /// </summary>
        public string SaveExtension = "dat";

        /// <summary>
        /// Combines the save path and filename. uses asset name for file name.
        /// </summary>
        /// <see cref="SaveMethod"/>
        public override string SavePath
        {
            get
            {
                if (SaveFilePath == "")
                    return Application.persistentDataPath + name + "." + SaveExtension;
                return SaveFilePath + name + SaveExtension;
            }
        }

        /// <summary>
        /// checks to see if the save file exists
        /// </summary>
        /// <see cref="SaveMethod"/>
        public override bool HasSave
        {
            get
            {
                return File.Exists(SavePath);
            }
        }

        /// <summary>
        /// checks to see what the last access time was for the save file or returns a default time.
        /// </summary>
        /// <see cref="SaveMethod"/>
        public override DateTime LastSave
        {
            get
            {
                if (HasSave)
                    return File.GetLastAccessTime(SavePath);
                return new DateTime(1900,1,1);
            }

        }

        /// <summary>
        /// display name for the save file
        /// </summary>
        /// <see cref="SaveMethod"/>
        public override string SaveName
        {
            get
            {
                return "~/"+ name + "." + SaveExtension;
            }
        }

        /// <summary>
        /// loads the binary file and deserializes it into a Dictionary
        /// </summary>
        /// <param name="data">the data structure to load</param>
        /// <returns>the loaded data</returns>
        /// <see cref="SaveMethod"/>
        public override Dictionary<int, string> LoadData(Dictionary<int, string> data)
        {
            //Dictionary<int, string> data = new Dictionary<int, string>();
            if (File.Exists(SavePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(SavePath);
                data = (Dictionary<int, string>)bf.Deserialize(file);
                file.Close();
                Debug.Log("SaveBinaryFile::LoadData() ==> Binary Data Loaded");
            }
            else
                Debug.LogError("SaveBinaryFile::LoadData() ==> File Missing?!");
            return data;
        }

        /// <summary>
        /// serialize the data into a binary file and write it to the disk
        /// </summary>
        /// <param name="data">data to save</param>
        /// <see cref="SaveMethod"/>
        public override void SaveData(Dictionary<int, string> data)
        {
            // save the data to a binary file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SavePath, FileMode.OpenOrCreate);
            bf.Serialize(file, data);
            file.Close();
            if (File.Exists(SavePath))
                Debug.Log("SaveBinaryFile::SaveData() ==> Binary Data Saved");
            else
                Debug.LogError("SaveBinaryFile::SaveData() ==> Binary Data NOT Saved!?!");
        }

        /// <summary>
        /// clears out all of the save data
        /// </summary>
        /// <param name="data">data structure to clear out</param>
        /// <see cref="SaveMethod"/>
        public override void ClearData(Dictionary<int, string> data)
        {
            // remove saved data...
            if (File.Exists(SavePath))
                File.Delete(SavePath);
        }

        /// <summary>
        /// returns the height of the item property drawer
        /// </summary>
        /// <param name="line_height">height of a line</param>
        /// <returns>height of the element</returns>
        /// <see cref="IListItemDrawer"/>
        public override float GetElementHeight(float line_height)
        {
            return base.GetElementHeight(line_height) + line_height;
        }

        /// <summary>
        /// draws the custom item property view for this save method
        /// </summary>
        /// <param name="rect">size of the element</param>
        /// <param name="line_height">height of a line</param>
        /// <see cref="IListItemDrawer"/>
        public override void OnDrawElement(Rect rect, float line_height)
        {
            base.OnDrawElement(rect, line_height);
            SaveExtension = EditorGUI.TextField(
                new Rect(new Vector2(rect.position.x, rect.position.y + (line_height*2)), new Vector2(rect.width, line_height-2)),
                "Extension",
                SaveExtension);
        }

    }
}