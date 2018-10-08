# Shared Variable Save System
Some scriptable objects for sharing data between game elements and a system for saving the runtime values of those shared variables.
Based on this tutorial: https://unity3d.com/how-to/architect-with-Scriptable-Objects and now updated to use generics based on this: https://fishtrone.wordpress.com/2018/09/16/saving-scriptable-object-variables/


# How to use
* Create a new [SaveObject](SaveObject) (Asssets->Create->Save System)
* Create a new *Save Method* (Asssets->Create->Save System->Save Method)
* Create *Variables* you want to have saved (Asssets->Create->Save System->Variables)
* Put *Variables* and *Save Method* in folder with the same name as the *SaveObject*
* Add *Variables* to [SaveObject](SaveObject)'s Data list. (click "Find" to find all variables and save methods under /[SaveObjectName]/ folder.)
* Write classes use *Variables* to store and share data.

