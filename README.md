# Shared Variable Save System

Some scriptable objects for sharing data between game elements and a system for saving the runtime values of those shared variables.
Based on this tutorial: *[architect with scriptable objects](https://unity3d.com/how-to/architect-with-Scriptable-Objects)* and now updated to use generics based on this: *[saving scriptable object variables](https://fishtrone.wordpress.com/2018/09/16/saving-scriptable-object-variables/)*

## How to use

* Create a new *SaveObject* (under the asset create menu)
* Create *Variables* you want to have saved (Assets->Create->Variables)
* Put *Variables* in folder with the same name as the *SaveObject*
* Add *Variables* to *SaveObject's* Data list. (click search for variables to find all variables under /[SaveObjectName]/ folder.)
* Create *SaveMethod* for where you want to save (Binary or PlayerPrefs)
* Add *SaveMethod* to save *SaveObject*
* Write classes use *Variables* to store and share data.
* You can write your own *SaveMethods* to extend the system to save to remote locations.

### [Documentation](https://sophiathekitty.github.io/SharedVariableSaveSystem/html/index.html)

### Tutorials

* [Coming soon](https://github.com/sophiathekitty/SharedVariableSaveSystem/wiki)
