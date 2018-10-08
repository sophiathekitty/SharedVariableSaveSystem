using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.VarTypes
{
    [TestFixture]
    public abstract class RangeVariableTests<T> : SharedVariableTests<T>
    {
        public RangeVariable<T> rangeVariable;
        public float min = 01;
        public float max = 10;
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _30_Over()
        {
            Assert.IsNotNull(rangeVariable);
            Assert.AreNotEqual(min, max);

            rangeVariable.Percent = 2;

            yield return null;

            Assert.AreEqual(max, rangeVariable.FloatValue);
        }
        /// <summary>
        /// Make sure that the has save works
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public virtual IEnumerator _40_Under()
        {
            Assert.IsNotNull(rangeVariable);
            Assert.AreNotEqual(min, max);

            rangeVariable.Percent = -2;

            yield return null;

            Assert.AreEqual(min, rangeVariable.FloatValue);
        }
    }
}
