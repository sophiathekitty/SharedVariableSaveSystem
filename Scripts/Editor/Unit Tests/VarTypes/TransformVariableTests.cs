using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SharedVariableSaveSystem.Tests.VarTypes
{
    /// <summary>
    /// test fixture for transform variable
    /// </summary>
    [TestFixture]
    public class TransformVariableTests : SavableVariableTest
    {
        TransformVariable transformVariable = ScriptableObject.CreateInstance<TransformVariable>();
        Transform transform;
        Vector3 iPos, iRot, iSca;
        Vector3 rPos, rRot, rSca;

        /// <summary>
        /// setup test data
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public override IEnumerator _00_Setup()
        {
            transform = Camera.main.transform;

            Assert.IsNotNull(transformVariable);
            transformVariable.InitialPosition = transformVariable.InitialRotation = transformVariable.InitialScale = iPos = iRot = iSca = Vector3.up;
            transformVariable.RuntimePosition = transformVariable.RuntimeRotation = transformVariable.RuntimeScale = rPos = rRot = rSca = Vector3.down;

            savableVariable = (SavableVariable)transformVariable;
            Assert.IsNotNull(savableVariable);

            yield return null;

            Assert.AreNotEqual(transformVariable.InitialPosition, transformVariable.RuntimePosition);
            Assert.AreNotEqual(transformVariable.InitialRotation, transformVariable.RuntimeRotation);
            Assert.AreNotEqual(transformVariable.InitialScale, transformVariable.RuntimeScale);

            Assert.AreEqual(iPos, transformVariable.InitialPosition);
            Assert.AreEqual(iRot, transformVariable.InitialRotation);
            Assert.AreEqual(iSca, transformVariable.InitialScale);

            Assert.AreEqual(rPos, transformVariable.RuntimePosition);
            Assert.AreEqual(rRot, transformVariable.RuntimeRotation);
            Assert.AreEqual(rSca, transformVariable.RuntimeScale);
        }
        /// <summary>
        /// validate that it can get data from a transform referense
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator _30_SetTransform()
        {
            transformVariable.RuntimeValue = transform;
            yield return null;

            Assert.AreEqual(transform.position, transformVariable.RuntimePosition,"Position was wrong");
            Assert.AreEqual(transform.localEulerAngles, transformVariable.RuntimeRotation, "Rotation was wrong");
            Assert.AreEqual(transform.localScale, transformVariable.RuntimeScale, "Scale was wrong");
        }
    }
}