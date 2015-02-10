using CAC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Rovnice
    {
        [TestMethod]
        public void RovniceScitaniOdcitani()
        {
            decimal[] test = { 10, 15, 20 };
            Assert.AreEqual(new Equation("X0+X1-X2", test).Evaluate(), 5);
        }
        [TestMethod]
        public void RovniceNasobeniDeleni()
        {
            decimal[] test = { 10, 15, 20 };
            Assert.AreEqual(new Equation("X0*X1/X2", test).Evaluate(), 7.5);
        }
        [TestMethod]
        public void RovniceKomplexniPriklad()
        {
            decimal[] test = { 10, 15, 20, 12, 3 };
            Assert.AreEqual(new Equation("(20+X0)/X1+X2*X3-X4", test).Evaluate(), 239);
        }

        [TestMethod]
        public void ValidatorRovnice()
        {
            Assert.IsTrue(EquationValidator.IsValid("X0+1*X1"));
            Assert.IsTrue(EquationValidator.IsValid("25+3"));
            Assert.IsFalse(EquationValidator.IsValid("invalidstring"));

        }
    }
}
