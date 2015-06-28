#region

using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using CAC;
using CAC.IO_Forms;
using CAC.Mathematic;
using CAC.sourceCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace UnitTests
{
    [TestClass]
    public class sourceCodes
    {
        private static void Reset()
        {
            PrivateType o=new PrivateType(typeof(SourceCodes));
            o.SetStaticField("_sourceDir",null);
        }
        private static List<SourceCode> SourceCodeFiles()
        {
            var o = new PrivateType(typeof(SourceCodes));
            var sourceCodeFiles = (List<SourceCode>)o.GetStaticField("_sourceCodeFiles");
            return sourceCodeFiles;
        }

        [TestMethod]
        public void SetPath()
        {
            Assert.IsTrue(SourceCodes.SetPath(@"D:\CAC\unitTests\returnSameNum"));
            Assert.IsFalse(SourceCodes.SetPath(@"D:\CAC\unitTests\nonEXISTING"));
        }

        [TestMethod]
        public void GetPath()
        {
            Reset();
            Assert.IsNull(SourceCodes.GetPath());
            SourceCodes.SetPath(@"D:\CAC\unitTests\returnSameNum");
            Assert.AreEqual(@"D:\CAC\unitTests\returnSameNum", SourceCodes.GetPath());
        }

        [TestMethod]
        public void IsDirectorySet()
        {
            Reset();
            Assert.IsFalse(SourceCodes.IsDirectorySet());
            SourceCodes.SetPath(@"D:\CAC\unitTests\returnSameNum");
            Assert.IsTrue(SourceCodes.IsDirectorySet());
        }
        [TestMethod]
        public void ReloadSourceCodeFiles()
        {
            Reset();
            SourceCodes.SetPath(@"D:\CAC\unitTests\threeFiles");
            SourceCodes.ReloadSourceCodeFiles();
            List<SourceCode> sourceCodeFiles = SourceCodeFiles();
            Assert.IsTrue(sourceCodeFiles.Count==3);
        }

        [TestMethod]
        public void GetSourceCodeFiles()
        {
            Reset();
            SourceCodes.SetPath(@"D:\CAC\unitTests\threeFiles");
            SourceCodes.ReloadSourceCodeFiles();
            CollectionAssert.AreEquivalent(SourceCodeFiles(), SourceCodes.GetSourceCodeFiles());
        }
        [TestMethod]
        public void GetSourceCodeById()
        {
            Reset();
            SourceCodes.SetPath(@"D:\CAC\unitTests\threeFiles");
            SourceCodes.ReloadSourceCodeFiles();
            SourceCode code = SourceCodes.GetSourceCode(1);
            Assert.AreEqual("main2.c", code.Name);
        }
        [TestMethod]
        public void GetSourceCodeByName()
        {
            Reset();
            SourceCodes.SetPath(@"D:\CAC\unitTests\threeFiles");
            SourceCodes.ReloadSourceCodeFiles();
            SourceCode code = SourceCodes.GetSourceCode("main2.c");
            Assert.AreEqual("main2.c", code.Name);
        }
    }
}