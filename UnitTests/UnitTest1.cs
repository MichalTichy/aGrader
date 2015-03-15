using System.Collections.Generic;
using CAC;
using CAC.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Rovnice
    {
        [TestMethod]
        public void RovniceScitaniOdcitani()
        {
            Dictionary<string,decimal> test=new Dictionary<string, decimal>()
            {
                {"X0",10},
                {"X1",15},
                {"X2",20}
            };
            Assert.AreEqual(new Equation("X0+X1-X2", test).Evaluate(), 5);
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
            Assert.IsTrue(EquationValidator.IsValid("X0+1*X1"));
            Assert.IsTrue(EquationValidator.IsValid("25+3"));
            Assert.IsFalse(EquationValidator.IsValid("invalidstring"));
            Assert.IsTrue(EquationValidator.IsValid("X2+X3+X5+X8"));
        }
    }
}