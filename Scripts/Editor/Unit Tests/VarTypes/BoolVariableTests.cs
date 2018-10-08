using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class BoolVariableTests : SharedVariableTests<bool>
    {
        BoolVariable boolVariable = ScriptableObject.CreateInstance<BoolVariable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(boolVariable);
            boolVariable.InitialValue = iVal = true;
            boolVariable.RuntimeValue = rVal = false;

            savableVariable = (SavableVariable)boolVariable;
            sharedVariable = (SharedVariable<bool>)boolVariable;

            yield return null;

            Assert.AreNotEqual(boolVariable.InitialValue, boolVariable.RuntimeValue);
            Assert.AreEqual(iVal, boolVariable.InitialValue);
            Assert.AreEqual(rVal, boolVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}