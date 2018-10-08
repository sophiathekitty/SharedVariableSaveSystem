using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class StringVariableTests : SharedVariableTests<string>
    {
        StringVariable boolVariable = ScriptableObject.CreateInstance<StringVariable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(boolVariable);
            boolVariable.InitialValue = iVal = "test 1";
            boolVariable.RuntimeValue = rVal = "test 2";

            savableVariable = (SavableVariable)boolVariable;
            sharedVariable = (SharedVariable<string>)boolVariable;

            yield return null;

            Assert.AreNotEqual(boolVariable.InitialValue, boolVariable.RuntimeValue);
            Assert.AreEqual(iVal, boolVariable.InitialValue);
            Assert.AreEqual(rVal, boolVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}