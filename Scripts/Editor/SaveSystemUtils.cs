using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemUtils {

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
