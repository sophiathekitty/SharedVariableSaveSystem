using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.SaveMethods
{
    /// <summary>
    /// test fixture for save to binary file
    /// </summary>
    [TestFixture]
    public class BinarySaveTests : SaveMethodTests
    {
        SaveBinaryFile saveBinary = ScriptableObject.CreateInstance<SaveBinaryFile>();
        /// <summary>
        /// save and load data
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public override IEnumerator _1_SaveAndLoad()
        {
            saveMethod = (SaveMethod)saveBinary;
            Assert.IsNotNull(saveBinary, "save binary is null?");
            yield return base._1_SaveAndLoad();
            FileAssert.Exists(saveBinary.SavePath);
        }
    }
}
