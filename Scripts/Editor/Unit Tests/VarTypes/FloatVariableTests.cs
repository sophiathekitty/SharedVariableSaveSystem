using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class FloatVariableTests : SharedVariableTests<float>
    {
        FloatVariable floatVariable = ScriptableObject.CreateInstance<FloatVariable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(floatVariable);
            floatVariable.InitialValue = iVal = 1;
            floatVariable.RuntimeValue = rVal = 2;

            savableVariable = (SavableVariable)floatVariable;
            sharedVariable = (SharedVariable<float>)floatVariable;

            yield return null;

            Assert.AreNotEqual(floatVariable.InitialValue, floatVariable.RuntimeValue);
            Assert.AreEqual(iVal, floatVariable.InitialValue);
            Assert.AreEqual(rVal, floatVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}