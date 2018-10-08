using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class IntVariableTests : SharedVariableTests<int>
    {
        IntVariable intVariable = ScriptableObject.CreateInstance<IntVariable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(intVariable);
            intVariable.InitialValue = iVal = 1;
            intVariable.RuntimeValue = rVal = 2;

            savableVariable = (SavableVariable)intVariable;
            sharedVariable = (SharedVariable<int>)intVariable;

            yield return null;

            Assert.AreNotEqual(intVariable.InitialValue, intVariable.RuntimeValue);
            Assert.AreEqual(iVal, intVariable.InitialValue);
            Assert.AreEqual(rVal, intVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}