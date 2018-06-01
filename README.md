# Shared Variable Save System
Some scriptable objects for sharing data between game elements and a system for saving the runtime values of those shared variables.
Based on this tutorial: https://unity3d.com/how-to/architect-with-Scriptable-Objects


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

# Variable Types

## BoolVariable : SavableVariable
### Properties
* bool InitialValue - the initial/default value
* bool RuntimeValue - the runtime value (this is what's saved and loaded)

## FloatVariable : SavableVariable
### Properties
* float InitialValue - the initial/default value
* float RuntimeValue - the runtime value (this is what's saved and loaded)

## IntVariable : SavableVariable
### Properties
* int InitialValue - the initial/default value
* int RuntimeValue - the runtime value (this is what's saved and loaded)

## StringVariable : SavableVariable
### Properties
* string InitialValue - the initial/default value
* string RuntimeValue - the runtime value (this is what's saved and loaded)

## Vector3Variable : SavableVariable
### Properties
* Vector3 InitialValue - the initial/default value
* Vector3 RuntimeValue - the runtime value (this is what's saved and loaded)

## Vector3IntVariable : SavableVariable
### Properties
* Vector3Int InitialValue - the initial/default value
* Vector3Int RuntimeValue - the runtime value (this is what's saved and loaded)

## TranformVariable : SavableVariable
### Properties
* Vector3 InitialPosition - the initial/default position
* Vector3 InitialRotation - the initial/default rotation
* Vector3 InitialScale - the initial/default scale
* Vector3 RuntimeVPosition - the runtime position (this is what's saved and loaded)
* Vector3 RuntimeRotation - the runtime rotation (this is what's saved and loaded)
* Vector3 RuntimeScale - the runtime scale (this is what's saved and loaded)
