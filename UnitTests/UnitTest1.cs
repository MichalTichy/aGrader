using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CAC;
using CAC.IO_Forms;
using CAC.Math;
using CAC.SourceCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    //todo usporadat
    [TestClass]
    public class Rovnice
    {
        [TestMethod]
        public void RovniceScitaniOdcitani()
        {
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
            {
                {"X0",10},
                {"X1",15},
                {"X2",20}
            };
            Assert.AreEqual(new Equation("X0+X1-X2", test).Evaluate(), 5);
        }

        [TestMethod]
        public void RovniceZbytekPoDeleni()
        {
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
            {
                {"X0",11}
            };
            Assert.AreEqual(new Equation("X0%2", test).Evaluate(), 1);
        }
        [TestMethod]
        public void RovniceNasobeniDesetinych()
        {
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
            {
                {"X0",(decimal) 27.94271145385820580}
            };
            new Equation("X0*4", test).Evaluate();
        }

        [TestMethod]
        public void RovniceNasobeniDeleni()
        {
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
            {
                {"X0",10},
                {"X1",15},
                {"X2",20}
            };
            Assert.AreEqual(new Equation("X0*X1/X2", test).Evaluate(), 7.5);
        }

        [TestMethod]
        public void RovniceKomplexniPriklad()
        {
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
            {
                {"X0",10},
                {"X1",15},
                {"X2",20},
                {"X3",12},
                {"X4",3}
            };
            Assert.AreEqual(new Equation("(20+X0)/X1+X2*X3-X4", test).Evaluate(), 239);
        }

        [TestMethod]
        public void ValidatorRovnice()
        {
            Assert.IsTrue(EquationValidator.IsValid("X0+1*X1", new List<string>() { "X0", "X1" }));
            Assert.IsTrue(EquationValidator.IsValid("25+3", new List<string>()));
            Assert.IsFalse(EquationValidator.IsValid("invalidstring", new List<string>()));
            Assert.IsTrue(EquationValidator.IsValid("X2+X3+X5+X8", new List<string>() { "X2", "X3", "X5", "X8" }));
            Assert.IsFalse(EquationValidator.IsValid("X2+X3+X5+X8", new List<string>() { "X9999", "X3", "X5", "X8" }));
        }
    }

    [TestClass]
    public class TestedCode
    {
        [TestMethod]
        public void IsCompilable()
        {
            SourceCode test = new SourceCode(@"D:\CAC\Hello-World.c");
            Assert.IsNull(test.GetCompilationErrorMessage());
            SourceCode test2 = new SourceCode(@"D:\CAC\Hello-World-BAD.c");
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