Implements: [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) 
# Description
Base abstract class for save methods. Used with [SaveObject](SaveObject) to save and load data.
# Properties
## _string_ SaveFilePath
The path to the save file. leave blank to save in default location
## _string_ SavePath
the parsed path to access the save data (file path or url)
## _string_ SaveName
the filename of the save file

***

# Methods
## _void_ SaveData(_Dictionary_&lt;_int_,_string_&gt; data)
saves the data
* Param: data - Data structure
## _Dictionary_&lt;_int_,_string_&gt; LoadData(_Dictionary_&lt;_int_,_string_&gt; data)
Converts runtime data to a string to be saved
* Param: data - Data structure
* Returns: String of runtime data
## _void_ ClearData(_Dictionary_&lt;_int_,_string_&gt; data)
clears data
* Param: data - Data structure
