Implements:  [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) > [SavableVariable](SavableVariable) > [SharedVariable](SharedVariable), [ISerializationCallbackReceiver](https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html)
# Description
Base abstract generic class for a range variable. Adds range limit utils
* type param: &lt;T&gt; Type of value for the range variable
# Properties
## _float_ MinValue
Lowest possible value
## _float_ MaxValue
Largest possible value
## _bool_ Descending
Inverts the percentage value of the range. MaxValue becomes 0% of the range
## _float_ FloatValue
Value used to calculate percentage of range.
* Used to access RuntimeValue for percent calculations
## _float_ Percent
Where the Runtime value is between the min and max values of the range.
* MinValue is 0% (0.0f) and Max Value is 100% (1.0f)
* If Descending is true MinValue is 100% and MaxValue is 0%
# [SharedVariable](SharedVariable) Properties
## _T_ InitialValue
The default value for the variable
## _T_ RuntimeValue {get; set;}
Run time value for the variable
# [SavableVariable](SavableVariable) Properties
## _bool_ Loaded
Set to true if data has been loaded

***

# Methods
## _void_ FitToRange
Ensures that the float value is within the min and max of the range.
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