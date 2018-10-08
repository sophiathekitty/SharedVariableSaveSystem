using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// base class for save methods
    /// </summary>
    /// <seealso cref="ISaveMethod"/>
    /// <seealso cref="IListItemDrawer"/>
    public abstract class SaveMethod : ScriptableObject, ISaveMethod, IListItemDrawer {
        /// <summary>
        /// the date and time that the save data was last written.
        /// </summary>
        public abstract DateTime LastSave { get; }
        /// <summary>
        /// The path to the save file
        /// </summary>
        public string SaveFilePath = "";
        /// <summary>
        /// returns true if there is save data available
        /// </summary>
        public abstract bool HasSave { get; }
        /// <summary>
        /// the parsed path to access the save data (file path or url)
        /// </summary>
        public abstract string SavePath { get; }
        /// <summary>
        /// the filename of the save file
        /// </summary>
        public abstract string SaveName { get; }
        /// <summary>
        /// Saves the data
        /// </summary>
        public abstract void SaveData(Dictionary<int,string> data);
        /// <summary>
        /// Loads the data
        /// </summary>
        public abstract Dictionary<int, string> LoadData(Dictionary<int, string> data);
        /// <summary>
        /// Clears the data
        /// </summary>
        public abstract void ClearData(Dictionary<int, string> data);
        /// <summary>
        /// draws the custom inspector view for the SaveObject list inspector.
        /// </summary>
        /// <param name="rect">the view area of the properter drawer</param>
        /// <param name="line_height">the height of a line</param>
        /// <see cref="IListItemDrawer"/>
        public virtual void OnDrawElement(Rect rect, float line_height)
        {
            GUI.Label(new Rect(rect.position, new Vector2(rect.width, line_height-2)), 
                SaveName );
            SaveFilePath = EditorGUI.TextField(
                new Rect(new Vector2(rect.position.x, rect.position.y + line_height), new Vector2(rect.width, line_height-2)),
                "Path",
                SaveFilePath);
        }
        /// <summary>
        /// the height of the list item view
        /// </summary>
        /// <param name="line_height">the height of a line</param>
        /// <returns>the height of the list item view</returns>
        /// <see cref="IListItemDrawer"/>
        public virtual float GetElementHeight(float line_height)
        {
            return line_height * 2 + 5;
        }
    }
}
