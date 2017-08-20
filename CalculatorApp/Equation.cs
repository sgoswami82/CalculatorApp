using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApp
{
    public class Equation
    {
        public Equation FirstOperand { get; set; }
        public Equation SecondOperand { get; set; }
        public string Operator { get; set; }
        private double result { get; set; }

        private Dictionary<string, Func<double, double, double>> methods = new Dictionary<string, Func<double, double, double>>()
        {
            { "+", (x, y) => x+y },
            { "-", (x, y) => x-y },
            { "*", (x, y) => x*y },
            { "/", (x, y) => x/y },
        };

        public double Calculate()
        {
            if (Operator != null)
                result = methods[Operator](FirstOperand.Calculate(), SecondOperand.Calculate());
            return result;
        }

        public void buildLogicTree(string equation)
        {
            int position = 0;
            bool _continue = true;

            methods.Keys.ToList().ForEach(x =>
            { if (equation.Contains(x) && _continue) { Operator = x; position = equation.IndexOf(Operator); _continue = false; } });

            if (Operator == null)
                result = Convert.ToDouble(equation);
            else
            {
                FirstOperand = new Equation();
                FirstOperand.buildLogicTree(equation.Substring(0, position));
                SecondOperand = new Equation();
                SecondOperand.buildLogicTree(equation.Substring(position + 1));
            }
        }
    }
}

