Implements: [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) 
# Description
Base abstract class for savable variables. Used with Save Object to save and load data.
# Properties
## _bool_ Loaded
Set to true if data has been loaded

***

# Methods
## _void_ OnClearSave()
Clear the saved data
## _string_ OnSaveData()
Converts runtime data to a string to be saved
* Returns: String of runtime data
## _void_ OnLoadData(string data)
Parses string of data into runtime data
* Param: data - Data to be loaded 
