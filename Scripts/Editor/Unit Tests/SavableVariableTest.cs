using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public abstract class SavableVariableTest
    {
        public SavableVariable savableVariable;
        private string saveData;
        /// <summary>
        /// setup the savableVariable
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator _00_Setup();

        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _10_Save()
        {
            // save method must be set
            Assert.IsNotNull(savableVariable);
            // Use the Assert class to test conditions.
            // yield to skip a frame
            saveData = savableVariable.OnSaveData();

            yield return null;

            Assert.AreEqual(saveData, savableVariable.OnSaveData());
        }

        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _20_Load()
        {
            // save method must be set
            Assert.IsNotNull(savableVariable);
            // Use the Assert class to test conditions.
            // yield to skip a frame
            savableVariable.OnLoadData(saveData);

            yield return null;

            Assert.AreEqual(saveData, savableVariable.OnSaveData());
        }
    }
}