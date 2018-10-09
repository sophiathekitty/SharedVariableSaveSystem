using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SharedVariableSaveSystem.Tests.SaveMethods
{
    /// <summary>
    /// test fixture for save methods
    /// </summary>
    [TestFixture]
    public abstract class SaveMethodTests
    {
        public Dictionary<int, string> testData = new Dictionary<int, string>();

        public SaveMethod saveMethod;

        private DateTime testTime;
        /// <summary>
        /// Make sure that it can save and load data. Creates some test data. save test data. muddy test data.
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _1_SaveAndLoad()
        {
            // save method must be set
            Assert.IsNotNull(saveMethod, "save method is null?!");
            // reset test data
            testData.Clear();
            testData.Add(1, "test1");
            // save test data
            testTime = DateTime.Now;
            saveMethod.SaveData(testData);
            // muddy test data
            testData[1] = "test2";
            yield return null;
            Assert.AreNotEqual("test1", testData[1]);
            // load test data
            testData = saveMethod.LoadData(testData);
            Assert.AreEqual("test1", testData[1]);
        }
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _2_HasSave()
        {
            // save method must be set
            Assert.IsNotNull(saveMethod);
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
            Assert.IsTrue(saveMethod.HasSave,"It doesn't think there's save data?");
        }
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _3_LastSave()
        {
            // save method must be set
            Assert.IsNotNull(saveMethod);
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
            DateTime dateTime = saveMethod.LastSave;
            Assert.AreEqual(testTime.Hour, saveMethod.LastSave.Hour);
        }
        /// <summary>
        /// Make sure that clearing data works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _4_ClearData()
        {
            // save method must be set
            Assert.IsNotNull(saveMethod);
            saveMethod.ClearData(testData);
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
            Assert.IsFalse(saveMethod.HasSave);
        }
    }
}