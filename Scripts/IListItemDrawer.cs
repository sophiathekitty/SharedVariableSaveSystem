using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SharedVariableSaveSystem
{
    /// <summary>
    /// interface for displaying custom property drawers for items in orderable list
    /// </summary>
    public interface IListItemDrawer
    {
        /// <summary>
        /// draws the custom inspector for an element in the list
        /// </summary>
        /// <param name="rect">the area to draw</param>
        /// <param name="line_height">height of a line</param>
        void OnDrawElement(Rect rect, float line_height);
        /// <summary>
        /// returns the height of the element in the list
        /// </summary>
        /// <param name="line_height">height of a line</param>
        /// <returns>height of element</returns>
        float GetElementHeight(float line_height);
    }
}