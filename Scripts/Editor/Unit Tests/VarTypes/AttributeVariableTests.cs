using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class AttributeVariableTests : SharedVariableTests<float>
    {
        AttributeVariable attributeVariable = ScriptableObject.CreateInstance<AttributeVariable>();

        float iMax = 3;
        float rMax = 4;
        float iUn = 0;
        float rUn = 0;

        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(attributeVariable);

            attributeVariable.InitialValue = iVal = 1;
            attributeVariable.RuntimeValue = rVal = 2;
            attributeVariable.InitialMax = iMax;
            attributeVariable.RuntimeMax = rMax;
            attributeVariable.InitialUnavailable = iUn;
            attributeVariable.RuntimeUnavailable = 0;

            savableVariable = (SavableVariable)attributeVariable;
            sharedVariable = (SharedVariable<float>)attributeVariable;

            yield return base._00_Setup();
        }

        [UnityTest]
        public IEnumerator _30_Over()
        {
            attributeVariable.RuntimeValue = rMax+10;

            yield return null;

            Assert.AreEqual(rMax, attributeVariable.RuntimeValue);

        }

        [UnityTest]
        public IEnumerator _40_Under()
        {
            attributeVariable.RuntimeValue = -1;

            yield return null;

            Assert.AreEqual(0, attributeVariable.RuntimeValue, "Shouldn't be able to go bellow zero.");

        }
        [UnityTest]
        public IEnumerator _50_Unavailable()
        {
            attributeVariable.RuntimeUnavailable = iUn;
            attributeVariable.RuntimeValue = rMax;

            yield return null;

            Assert.AreEqual(rMax - iUn, attributeVariable.RuntimeValue,"Unavailable should be subtracted from the max.");
        }

    }
}