using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.SaveMethods
{
    [TestFixture]
    public class BinarySaveTests : SaveMethodTests
    {
        SaveBinaryFile saveBinary = ScriptableObject.CreateInstance<SaveBinaryFile>();

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
