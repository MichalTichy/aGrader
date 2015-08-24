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
    public class Test
    {
        [TestMethod]
        public void ReturnSameNum3X()
        {
            SourceCodes.SetPath(@"D:\CAC\tests\returnSameNum3x\");
            SourceCodes.ReloadSourceCodeFiles("c");
            XmlManager.Import(@"D:\CAC\tests\returnSameNum3x\SameNum3x.xml");

            TestManager.TestAllSourceCodes();

            AllCodesPassed();
        }

        private void AllCodesPassed()
        {
            foreach (SourceCode sourceCode in SourceCodes.GetSourceCodeFiles())
            {
                Assert.IsTrue(sourceCode.TestResult.IsOk==true);
            }
        }
    }
}