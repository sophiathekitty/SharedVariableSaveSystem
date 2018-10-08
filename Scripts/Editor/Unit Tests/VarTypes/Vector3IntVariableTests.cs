using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class Vector3IntVariableTests : SharedVariableTests<Vector3Int>
    {
        Vector3IntVariable floatVariable = ScriptableObject.CreateInstance<Vector3IntVariable>();

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(floatVariable);
            floatVariable.InitialValue = iVal = Vector3Int.up;
            floatVariable.RuntimeValue = rVal = Vector3Int.down;

            savableVariable = (SavableVariable)floatVariable;
            sharedVariable = (SharedVariable<Vector3Int>)floatVariable;

            yield return null;

            Assert.AreNotEqual(floatVariable.InitialValue, floatVariable.RuntimeValue);
            Assert.AreEqual(iVal, floatVariable.InitialValue);
            Assert.AreEqual(rVal, floatVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
        }
    }
}