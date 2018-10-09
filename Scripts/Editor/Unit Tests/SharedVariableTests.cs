using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.VarTypes
{
    /// <summary>
    /// generic abstract text fixture for shared variable
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    [TestFixture]
    public abstract class SharedVariableTests<T> : SavableVariableTest
    {
        public SharedVariable<T> sharedVariable;
        public T iVal;
        public T rVal;

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(sharedVariable, "sharedVariable needs to be set for tests to work.");
            Assert.IsNotNull(savableVariable, "savableVariable needs to be set for tests to work.");

            Assert.AreNotEqual(sharedVariable.InitialValue, sharedVariable.RuntimeValue, "Initial value and Runtime Value shouldn't be the same.");
            Assert.AreEqual(iVal, sharedVariable.InitialValue, "Initial value not resolving as expected?");
            Assert.AreEqual(rVal, sharedVariable.RuntimeValue, "Runtime value not resolving as expected?");

            return null;
        }
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _80_Muddy()
        {
            Assert.AreNotEqual(iVal, rVal, "Initial value and Runtime Value shouldn't be the same.");
            sharedVariable.RuntimeValue = rVal;
            yield return null;
            Assert.AreNotEqual(sharedVariable.InitialValue, sharedVariable.RuntimeValue, "Initial value and Runtime Value shouldn't be the same.");
        }
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _90_Reset()
        {
            sharedVariable.OnAfterDeserialize();
            // yield to skip a frame
            yield return null;
            Assert.AreEqual(sharedVariable.InitialValue, sharedVariable.RuntimeValue, "Initial value and Runtime Value should be the same after OnAfterDeserialize is called.");
        }

        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _99_Passes()
        {
            yield return null;

            Assert.AreNotEqual(iVal, rVal, "Initial value and Runtime Value shouldn't be the same.");
            Assert.AreEqual(iVal, sharedVariable.InitialValue, "Initial value not resolving as expected?");
        }

    }
}
