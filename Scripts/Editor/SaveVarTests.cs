using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystemTests
{

    public class SaveVarTests
    {


        [UnityTest]
        public IEnumerator Int_save_load()
        {
            const int testData = 5;
            IntVariable test = new IntVariable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator Float_save_load()
        {
            const float testData = 0.5f;
            FloatVariable test = new FloatVariable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator Bool_save_load()
        {
            const bool testData = true;
            BoolVariable test = new BoolVariable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator String_save_load()
        {
            const string testData = "test datas";
            StringVariable test = new StringVariable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator Vector3_save_load()
        {
            Vector3 testData = new Vector3(1, 2, 3);
            Vector3Variable test = new Vector3Variable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

        [UnityTest]
        public IEnumerator Vector3Int_save_load()
        {
            Vector3Int testData = new Vector3Int(1, 2, 3);
            Vector3IntVariable test = new Vector3IntVariable
            {
                RuntimeValue = testData
            };
            yield return null;
            test.OnLoadData(test.OnSaveData());
            Assert.AreEqual(testData, test.RuntimeValue);
        }

    } // class
} // namespace