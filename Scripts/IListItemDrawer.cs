using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListItemDrawer {
    void OnDrawElement(Rect rect, float line_height);
    float GetElementHeight(float line_height);
}
