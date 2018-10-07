using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace SharedVariableSaveSystem.Tests.SaveMethods
{
    [TestFixture]
    public class SavePlayerPrefsTests : SaveMethodTests
    {
        SavePlayerPrefs savePlayerPrefs = ScriptableObject.CreateInstance<SavePlayerPrefs>();

        [UnityTest]
        public override IEnumerator _1_SaveAndLoad()
        {
            savePlayerPrefs.SaveFilePath = "test";
            saveMethod = (SaveMethod)savePlayerPrefs;
            Assert.IsNotNull(savePlayerPrefs);
            yield return base._1_SaveAndLoad();
            //yield return null;
            Assert.IsTrue(PlayerPrefs.HasKey(savePlayerPrefs.SavePath + "LastSave"), "["+savePlayerPrefs.SavePath + "LastSave] player pref key is missing");
            Assert.AreEqual("test1", PlayerPrefs.GetString(savePlayerPrefs.SavePath + "1"));
        }
    }
}

