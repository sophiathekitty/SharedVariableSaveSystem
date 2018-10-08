Implements:  [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) > [SavableVariable](SavableVariable) > [SharedVariable](SharedVariable), [ISerializationCallbackReceiver](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html)
# Description
Scriptable Object for storing a character attribute. like HP. Includes an Unavailable amount. ie: sickness reducing max health.
* type param: &lt;float&gt; generic cast as float
# Properties
## _float_ InitialMax
The default max value
## _float_ InitialUnavailable
The default unavailable value
## _float_ RuntimeMax
The run time max value
## _float_ RuntimeUnavailable
The run time unavailable
## _float_ Percent
The percent of the run time range between 0 and run time max the run time value is at.

# [SharedVariable](SharedVariable) Properties
## _float_ InitialValue
The default value for the variable
## _float_ RuntimeValue {get; set;}
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