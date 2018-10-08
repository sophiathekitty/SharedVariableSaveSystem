using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public class FloatRangeVariableTests : RangeVariableTests<float>
    {
        FloatRangeVariable floatRangeVariable = ScriptableObject.CreateInstance<FloatRangeVariable>();
        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(floatRangeVariable);
            floatRangeVariable.InitialValue = iVal = min;
            floatRangeVariable.RuntimeValue = rVal = max;
            floatRangeVariable.MaxValue = max;
            floatRangeVariable.MinValue = min;

            savableVariable = (SavableVariable)floatRangeVariable;
            sharedVariable = (SharedVariable<float>)floatRangeVariable;
            rangeVariable = (RangeVariable<float>)floatRangeVariable;

            yield return null;

            Assert.AreNotEqual(floatRangeVariable.InitialValue, floatRangeVariable.RuntimeValue);
            Assert.AreEqual(iVal, floatRangeVariable.InitialValue);
            Assert.AreEqual(rVal, floatRangeVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
            Assert.IsNotNull(sharedVariable);
            Assert.IsNotNull(rangeVariable);
        }
    }
}
