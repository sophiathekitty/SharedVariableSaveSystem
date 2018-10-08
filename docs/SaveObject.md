Implements: [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) 
# Description
Holds a set of references to Savable Variables.
# Properties
## _bool_ HasSave
Whether or not a save file exists
## _List&lt;[SaveMethod](SaveMethod)&gt;_ SaveLocations
List of save methods/locations to use
## _List&lt;[SavableVariable](SavableVariable)&gt;_ Data
List of the savable variables to save

***

# Methods
## _void_ SaveData()
Saves the data
## _void_ LoadData()
Loads the data
* Returns: String of runtime data
## _void_ clearSaveData()
Reset data
