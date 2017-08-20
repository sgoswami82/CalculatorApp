using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace UnitTestCalculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void EmptyStringValidate()
        {
            Calculator Calc = new Calculator();
            string error = string.Empty;
            double output = Calc.Calculate("", ref error);
            Assert.AreEqual(Calculator.DescriptiveErrors[Calculator.ERROR_EMPTY_STRING], error);
            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void DivideByZeroValidate()
        {
            Calculator Calc = new Calculator();
            string error = string.Empty;
            double output = Calc.Calculate("3/0", ref error);
            Assert.AreEqual(Calculator.DescriptiveErrors[Calculator.ERROR_DIVIDEBYZERO], error);
            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void InputFormatValidate()
        {
            Calculator Calc = new Calculator();
            string error = string.Empty;
            double output = Calc.Calculate("a+b+c", ref error);
            Assert.AreEqual(Calculator.DescriptiveErrors[Calculator.ERROR_INVALID_STRING], error);
            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void OperatorPrecedenceTest()
        {
            Calculator Calc = new Calculator();
            string error = string.Empty;
            double output = Calc.Calculate("39-12*3+20/10*2-3", ref error);
            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(4, output);
        }

        [TestMethod]
        public void SolveEquationTest()
        {
            Calculator Calc = new Calculator();
            string error = string.Empty;
            double output = Calc.Calculate("20-15+3*2", ref error);
            Assert.AreEqual(string.Empty, error);
            Assert.AreEqual(11, output);
        }
    }
}

