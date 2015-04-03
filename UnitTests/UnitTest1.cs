using System.Collections.Generic;
using CAC;
using CAC.IO_Forms;
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
            Dictionary<string, decimal> test = new Dictionary<string, decimal>()
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
            CAC.TestedCode test = new CAC.TestedCode(@"D:\CAC\Hello-World.c");
            Assert.IsNull(test.GetError());
            CAC.TestedCode test2 = new CAC.TestedCode(@"D:\CAC\Hello-World-BAD.c");
            Assert.IsNotNull(test2.GetError());
        }

        [TestMethod]
        public void Inputs()
        {
            CAC.TestedCode test = new CAC.TestedCode(@"D:\CAC\Hello-World.c");
            PrivateObject privateObject = new PrivateObject(test);
            List<string> correctValues = new List<string>();

            InputsOutputs.Add(new InputNumber(10));
            correctValues.Add("10");
            InputsOutputs.Add(new InputString("test"));
            correctValues.Add("test");

            privateObject.Invoke("GetInputsAndOutputs");
            List<string> inputs = (List<string>)privateObject.GetField("_inputs");

            CollectionAssert.IsSubsetOf(inputs, correctValues);
        }

        [TestMethod]
        public void Outputs()
        {
            CAC.TestedCode test = new CAC.TestedCode(@"D:\CAC\Hello-World.c");
            PrivateObject privateObject = new PrivateObject(test);

            InputsOutputs.Add(new OutputNumber(10));

            InputsOutputs.Add(new InputRandomNumber(1,100,false,1));
            InputsOutputs.Add(new InputRandomNumber(1, 100, false, 2));
            InputsOutputs.Add(new InputRandomNumber(1, 100, false, 3));
            InputsOutputs.Add(new OutputNumberBasedOnRandomInput("X1+X2+X3"));
            InputsOutputs.Add(new OutputString("TEST"));
            privateObject.Invoke("GetInputsAndOutputs");
            Dictionary<string, decimal> randomNumbers = (Dictionary<string, decimal>) privateObject.GetFieldOrProperty("_randomNumbers");


            List<string> outputs = (List<string>)privateObject.GetField("_outputs");

            Assert.IsTrue(outputs[0]=="10");
            Assert.IsTrue(outputs[1] == (randomNumbers["X1"] + randomNumbers["X2"] + randomNumbers["X3"]).ToString());
            Assert.IsTrue(outputs[2] == "TEST");
        }

    }
}