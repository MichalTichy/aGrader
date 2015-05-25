﻿#region

using System.Collections.Generic;
using System.Threading;
using CAC;
using CAC.IO_Forms;
using CAC.Mathematic;
using CAC.sourceCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace UnitTests
{
    //todo usporadat
    [TestClass]
    public class Rovnice
    {
        [TestMethod]
        public void RovniceScitaniOdcitani()
        {
            var test = new Dictionary<string, decimal>
            {
                {"X0", 10},
                {"X1", 15},
                {"X2", 20}
            };
            Assert.AreEqual(new Math("X0+X1-X2", test).Evaluate(), 5);
        }

        [TestMethod]
        public void RovniceZbytekPoDeleni()
        {
            var test = new Dictionary<string, decimal>
            {
                {"X0", 11}
            };
            Assert.AreEqual(new Math("X0%2", test).Evaluate(), 1);
        }

        [TestMethod]
        public void RovniceNasobeniDesetinych()
        {
            var test = new Dictionary<string, decimal>
            {
                {"X0", (decimal) 27.94271145385820580}
            };
            new Math("X0*4", test).Evaluate();
        }

        [TestMethod]
        public void RovniceNasobeniDeleni()
        {
            var test = new Dictionary<string, decimal>
            {
                {"X0", 10},
                {"X1", 15},
                {"X2", 20}
            };
            Assert.AreEqual(new Math("X0*X1/X2", test).Evaluate(), 7.5);
        }

        [TestMethod]
        public void RovniceKomplexniPriklad()
        {
            var test = new Dictionary<string, decimal>
            {
                {"X0", 10},
                {"X1", 15},
                {"X2", 20},
                {"X3", 12},
                {"X4", 3}
            };
            Assert.AreEqual(new Math("(20+X0)/X1+X2*X3-X4", test).Evaluate(), 239);
        }

        [TestMethod]
        public void ValidatorRovnice()
        {
            Assert.IsTrue(MathValidator.IsValid("X0+1*X1", new List<string> {"X0", "X1"}));
            Assert.IsTrue(MathValidator.IsValid("25+3", new List<string>()));
            Assert.IsFalse(MathValidator.IsValid("invalidstring", new List<string>()));
            Assert.IsTrue(MathValidator.IsValid("X2+X3+X5+X8", new List<string> {"X2", "X3", "X5", "X8"}));
            Assert.IsFalse(MathValidator.IsValid("X2+X3+X5+X8", new List<string> {"X9999", "X3", "X5", "X8"}));
        }
    }

    [TestClass]
    public class TestedCode
    {
        [TestMethod]
        public void IsCompilable()
        {
            var test = new SourceCode(@"D:\CAC\Hello-World.c");
            Assert.IsNull(test.GetCompilationErrorMessage());
            var test2 = new SourceCode(@"D:\CAC\Hello-World-BAD.c");
            Assert.IsNotNull(test2.GetCompilationErrorMessage());
        }

        [TestMethod]
        public void TestProgram1InputNumber()
        {
            InputsOutputs.Clear();
            InputsOutputs.Add(new InputNumber(25));
            InputsOutputs.Add(new OutputNumber(25));

            bool pathSetSuccesfully = SourceCodes.SetPath(@"D:\CAC\tests\returnSameNum");
            Assert.IsTrue(pathSetSuccesfully);

            TestManager.TestAllSourceCodes();
            int i = 0;
            Thread.Sleep(5000);
            TestResult result = SourceCodes.GetSourceCode(0).GetResult();
            Assert.IsTrue(result.Errors.Length == 0); //no errors ocured
            Assert.IsTrue(result.LinesWithBadOutput.Count == 0); //all outputs matched
        }

        [TestMethod]
        public void TestProgram2InputString()
        {
            InputsOutputs.Clear();
            InputsOutputs.Add(new InputString("test"));
            InputsOutputs.Add(new OutputString("test"));

            bool pathSetSuccesfully = SourceCodes.SetPath(@"D:\CAC\tests\returnSameString");
            Assert.IsTrue(pathSetSuccesfully);

            TestManager.TestAllSourceCodes();
            Thread.Sleep(5000);
            TestResult result = SourceCodes.GetSourceCode(0).GetResult();
            Assert.IsTrue(result.Errors.Length == 0); //no errors ocured
            Assert.IsTrue(result.LinesWithBadOutput.Count == 0); //all outputs matched
        }

        [TestMethod]
        public void TestProgram2ComplexProgramWithoutRandomNumbers()
        {
            InputsOutputs.Clear();
            InputsOutputs.Add(new InputString("test1"));
            InputsOutputs.Add(new InputNumber(250));
            InputsOutputs.Add(new OutputNumber(250));
            InputsOutputs.Add(new InputString("test2"));
            InputsOutputs.Add(new OutputString("test1 test2"));

            bool pathSetSuccesfully = SourceCodes.SetPath(@"D:\CAC\tests\ComplexProgramWithoutRandom");
            Assert.IsTrue(pathSetSuccesfully);

            TestManager.TestAllSourceCodes();
            Thread.Sleep(5000);
            TestResult result = SourceCodes.GetSourceCode(0).GetResult();
            Assert.IsTrue(result.Errors.Length == 0); //no errors ocured
            Assert.IsTrue(result.LinesWithBadOutput.Count == 0); //all outputs matched
        }
    }
}