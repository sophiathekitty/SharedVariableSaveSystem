using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// some utility functions for the custom editors
    /// </summary>
    public class SaveSystemUtils
    {
        /// <summary>
        /// converts a base64 image string into a texture2d image
        /// </summary>
        /// <param name="base64">base64 image</param>
        /// <returns>Texture2D image</returns>
        public static Texture2D Base64ToTexture(string base64)
        {
            Texture2D t = new Texture2D(1, 1)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            t.LoadImage(System.Convert.FromBase64String(base64));
            return t;
        }
    }
}
