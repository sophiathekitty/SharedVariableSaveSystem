using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class Vector3VariableTests : SharedVariableTests<Vector3>
    {
        Vector3Variable floatVariable = ScriptableObject.CreateInstance<Vector3Variable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(floatVariable);
            floatVariable.InitialValue = iVal = Vector3.up;
            floatVariable.RuntimeValue = rVal = Vector3.down;

            savableVariable = (SavableVariable)floatVariable;
            sharedVariable = (SharedVariable<Vector3>)floatVariable;

            yield return null;

            Assert.AreNotEqual(floatVariable.InitialValue, floatVariable.RuntimeValue);
            Assert.AreEqual(iVal, floatVariable.InitialValue);
            Assert.AreEqual(rVal, floatVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}