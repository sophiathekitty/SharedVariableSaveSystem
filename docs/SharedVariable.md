Implements:  [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) > [SavableVariable](SavableVariable), [ISerializationCallbackReceiver](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html)
# Description
Base abstract generic class for Scriptable Object variables. Extend this class to create new Savable Shared Variables.
* type param: &lt;T&gt; Type of value for the variable
# Properties
## _T_ InitialValue
The default value for the variable
## _T_ RuntimeValue {get; set;}
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