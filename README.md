# Shared Variable Save System
Some scriptable objects for sharing data between game elements and a system for saving the runtime values of those shared variables.
Based on this tutorial: https://unity3d.com/how-to/architect-with-Scriptable-Objects and now updated to use generics based on this: https://fishtrone.wordpress.com/2018/09/16/saving-scriptable-object-variables/


# How to use
* Create a new *SaveObject* (under the assset create menu)
* Create *Variables* you want to have saved (Asssets->Create->Variables)
* Put *Variables* in folder with the same name as the *SaveObject*
* Add *Variables* to *SaveObject's* Data list. (click search for variables to find all variables under /[SaveObjectName]/ folder.)
* Write classes use *Variables* to store and share data. 


# Classes

## SaveObject
### Properties
* SaveFileName - the save file name.
* SaveFilePath - the path to the save file. (blank uses default location)
* Data - list of SavableVariables.
### Methods
* void SaveData() - saves the Data to a file
* void LoadData() - loads the Data from a file
* void clearSaveData() - deletes the save file if it exists

## SavableVariable (Abstract class)
### Abstract Methods
* string OnSaveData() - returns data to be saved as a string
* void OnLoadData(string data) - pass string data to be loaded
* void OnClearSave() - reset the data

## SharedVariable<T> : SavableVariable, ISerializationCallbackReceiver (Abstract Generic class)
### Generic Properties
* T InitialValue - the initial/default value
* T RuntimeValue {get; set;} - the runtime value (this is what's saved and loaded)
### ISerializationCallbackReciever Methods
* void OnAfterDeserialize() { RuntimeValue = InitialValue; }
* void OnBeforeSerialize() { /*do nothing*/ }


# Variable Types

## BoolVariable : SharedVariable<bool>

## FloatVariable : SharedVariable<float>

## IntVariable : SharedVariable<int>

## StringVariable : SharedVariable<string>

## Vector3Variable : SharedVariable<Vector3>

## Vector3IntVariable : SharedVariable<Vector3Int>

## FloatRangeVariable : SharedVariable<float>
### Properties
* float MinValue - the min value of the range
* float MaxValue - the max value of the range
* bool Descending - if true min value is 100% and max is 0%
* float Percent - percentage between min and max

## IntRangeBariable : SharedVariable<int>
### Properties
* int MinValue - the min value of the range
* int MaxValue - the max value of the range
* bool Descending - if true min value is 100% and max is 0%
* float Percent - percentage between min and max

## AttributeVariable : SharedVariable<float>
## Properties
* float InitialMax - the initial/default max value
* float RuntimeMax - the runtime max value (this is what's saved and loaded)
* float InitialUnavailable - the initial/default unavailable (ie: fallout 4 radiation eating away your max health)
* float RuntimeUnavailable - the runtime unavailable (this is what's saved and loaded)

## TranformVariable : SavableVariable
### Properties
* Vector3 InitialPosition - the initial/default position
* Vector3 InitialRotation - the initial/default rotation
* Vector3 InitialScale - the initial/default scale
* Vector3 RuntimePosition - the runtime position (this is what's saved and loaded)
* Vector3 RuntimeRotation - the runtime rotation (this is what's saved and loaded)
* Vector3 RuntimeScale - the runtime scale (this is what's saved and loaded)
* Transform RuntimeValue {set;} - lets you set postion, rotaion, and scale from another transform
