Implements:  [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) > [SavableVariable](SavableVariable), [ISerializationCallbackReceiver](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html)
# Description
[ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) for saving and sharing transform data
# Properties
## _Vector3_ InitialPosition
The default position for the variable
## _Vector3_ InitialRotaion
The default rotation for the variable
## _Vector3_ InitialScale
The default scale for the variable
## _Vector3_ RuntimePosition
The run time position for the variable
## _Vector3_ RuntimeRotaion
The run time rotation for the variable
## _Vector3_ RunetimeScale
The run time scale for the variable
## _Transform_ RuntimeValue { set;}
Run time value for the variable
# [SavableVariable](SavableVariable) Properties
## _bool_ Loaded
Set to true if data has been loaded

***

# [ISerializationCallbackReceiver](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html) Methods
## _void_ OnAfterDeserialize
Applies the default value to the run time value after deserialization.
* This should happen after changing the default values in the inspector. It will also apply the default value when the game starts.
* Required for ISerializationCallbackReceiver
## _void_ OnBeforeSerialize()
Does nothing
* Required for ISerializationCallbackReceiver
# [SavableVariable](SavableVariable) Methods
## _void_ OnClearSave()
Clear the saved data
## _string_ OnSaveData()
Converts runtime data to a string to be saved
* Returns: String of runtime data
## _void_ OnLoadData(string data)
Parses string of data into runtime data
* Param: data - Data to be loaded 