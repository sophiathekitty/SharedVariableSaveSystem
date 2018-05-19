using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace SharedVariableSaveSystemTests
{
    [TestFixture]
    public class SaveSystemTest
    {
        [UnityTest]
        public IEnumerator _Save_Load_GameData()
        {
            SaveObject saveObject = new SaveObject();
            saveObject.saveFileName = "testData.dat";
            const int testData = 5;
            IntVariable testIntData = new IntVariable();
            testIntData.name = "TestData";
            testIntData.RuntimeValue = testData;
            saveObject.data = new List<SavableVariable>();
            saveObject.data.Add(testIntData);

            yield return null;

            saveObject.SaveData();

            FileAssert.Exists(saveObject.savePath);
            // blank out the data to simulate that it's been unloaded
            testIntData.RuntimeValue = testIntData.InitialValue;

            saveObject.LoadData();
            Assert.AreEqual(testData, testIntData.RuntimeValue);
            saveObject.clearSaveData();

            FileAssert.DoesNotExist(saveObject.savePath);
        }
    }

}
