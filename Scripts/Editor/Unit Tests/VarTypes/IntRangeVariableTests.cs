using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.VarTypes
{
    /// <summary>
    /// test fixture for int range variable
    /// </summary>
    [TestFixture]
    public class IntRangeVariableTests : RangeVariableTests<int>
    {
        IntRangeVariable intRangeVariable = ScriptableObject.CreateInstance<IntRangeVariable>();

        /// <summary>
        /// setup test data
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            Assert.IsNotNull(intRangeVariable);
            intRangeVariable.InitialValue = iVal = (int)min;
            intRangeVariable.RuntimeValue = rVal = (int)max;
            intRangeVariable.MaxValue = max;
            intRangeVariable.MinValue = min;

            savableVariable = (SavableVariable)intRangeVariable;
            sharedVariable = (SharedVariable<int>)intRangeVariable;
            rangeVariable = (RangeVariable<int>)intRangeVariable;

            yield return null;

            Assert.AreNotEqual(intRangeVariable.InitialValue, intRangeVariable.RuntimeValue);
            Assert.AreEqual(iVal, intRangeVariable.InitialValue);
            Assert.AreEqual(rVal, intRangeVariable.RuntimeValue);
            Assert.IsNotNull(savableVariable);
            Assert.IsNotNull(sharedVariable);
            Assert.IsNotNull(rangeVariable);
        }
    }
}
