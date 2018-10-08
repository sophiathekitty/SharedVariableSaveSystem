using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace SharedVariableSaveSystem.Tests
{
    [TestFixture]
    public class SaveObjectTest
    {
        SaveObject saveObject = ScriptableObject.CreateInstance<SaveObject>();
        IntVariable testIntData = ScriptableObject.CreateInstance<IntVariable>();
        SavePlayerPrefs playerPrefs = ScriptableObject.CreateInstance<SavePlayerPrefs>();
        const int testData = 5;
        const int testDefault = 10;

        [UnityTest]
        public IEnumerator _1_Setup()
        {
            testIntData.name = "TestData";
            testIntData.InitialValue = testDefault;
            testIntData.RuntimeValue = testData;
            saveObject.Data = new List<SavableVariable>();
            saveObject.Data.Add(testIntData);
            saveObject.SaveLocations = new List<SaveMethod>();
            saveObject.SaveLocations.Add(playerPrefs);

            yield return null;

            Assert.NotNull(saveObject);
            Assert.NotNull(testIntData);
            Assert.NotNull(playerPrefs);
            Assert.AreEqual(testDefault, testIntData.InitialValue);
            Assert.AreEqual(testData, testIntData.RuntimeValue);
            Assert.Contains(testIntData, saveObject.Data);
            Assert.Contains(playerPrefs, saveObject.SaveLocations);

        }

        [UnityTest]
        public IEnumerator _2_Save()
        {
            saveObject.SaveData();

            yield return null;

            Assert.IsTrue(saveObject.HasSave);
            // blank out the data to simulate that it's been unloaded
            testIntData.OnAfterDeserialize();
            Assert.AreEqual(testIntData.RuntimeValue, testIntData.InitialValue);
            Assert.AreNotEqual(testData, testIntData.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator _3_Load()
        {
            saveObject.LoadData();

            yield return null;

            Assert.AreEqual(testData, testIntData.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator _4_Clear()
        {

            saveObject.ClearSaveData();

            yield return null;

            Assert.False(saveObject.HasSave);
        }
    }

}
