using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CalculatorApp
{
    public class Calculator
    {
        #region define error codes
        public const string ERROR_EMPTY_STRING = "EMPTY",
                                ERROR_INVALID_STRING = "INVALID",
                                ERROR_DIVIDEBYZERO = "DIVZERO",
                                ERROR_GENERIC = "GENERIC";

        public static readonly Dictionary<string, string> DescriptiveErrors = new Dictionary<string, string>
        {
            { ERROR_DIVIDEBYZERO, "Divide by zero error encountered. Please check the equation." },
            { ERROR_EMPTY_STRING, "The input expression cannot be empty." },
            { ERROR_INVALID_STRING, "Input expression is in invalid format. Please make sure the expression contains only numbers and operators (+-*/)." },
            { ERROR_GENERIC, "An error occurred while evaluating the expression. Please check the expression." },
        };
        #endregion

        public string errorCode { get; set; }

        public double Calculate(string equation, ref string error)
        {
            double result = 0;
            try
            {
                if (IsExpressionValid(equation))
                {
                    Equation operation = new Equation();
                    operation.buildLogicTree(equation.Replace(" ", string.Empty));
                    result = operation.Calculate();
                    if ((result == double.PositiveInfinity) || (result == double.NegativeInfinity))
                        errorCode = ERROR_DIVIDEBYZERO;
                }
            }
            catch (Exception ex)
            {
                errorCode = ERROR_GENERIC;
            }

            if (errorCode != null)
            {
                error = DescriptiveErrors[errorCode];
                result = 0;
            }
            return result;
        }

        private bool IsExpressionValid(string equation)
        {
            if (string.IsNullOrWhiteSpace(equation))
                errorCode = ERROR_EMPTY_STRING;
            else
                if (!equation.All(c => "0123456789+-*/".Contains(c)))
                errorCode = ERROR_INVALID_STRING;

            if (errorCode == null)
                return true;
            else
                return false;
        }

        #region Alternate Solution using built in functionality
        public int DataTableImplementation(String Exp)
        {
            return Convert.ToInt32(new DataTable().Compute(Exp, null));
        }
        #endregion
    }
}
