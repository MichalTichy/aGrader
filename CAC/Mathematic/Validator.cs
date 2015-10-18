#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace aGrader.Mathematic
{
    public static class Validator
    {
        public static bool IsValidMath(string equation, IEnumerable<string> existingUnknowns)
        {
            Dictionary<string, decimal> numbersForEquation = GenerateNumbersForEquation(equation, existingUnknowns);

            foreach (KeyValuePair<string, decimal> pair in numbersForEquation)
                equation = equation.Replace(pair.Key, pair.Value.ToString());

            if (equation.Contains('X'))
            {
                MessageBox.Show("Matematický příklad obsahuje neexistující neznámou.");
                return false;
            }

            try
            {
                var eq = new MathExpresion(equation, numbersForEquation);
                eq.Evaluate();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Nezprávný tvar matematického příkladu!");
                return false;
            }
        }

        private static Dictionary<string, decimal> GenerateNumbersForEquation(string equation,
            IEnumerable<string> existingUnknowns)
        {
            var numbersForEquation = new Dictionary<string, decimal>();
            int i = 0;
            foreach (string unknownId in existingUnknowns)
            {
                i++;
                numbersForEquation.Add(unknownId, i);
            }
            return numbersForEquation;
        }

        public static bool IsValidBooleanExpression(string expression, IEnumerable<string> existingUnknowns)
        {
            try
            {
                new BooleanExpresion(expression, GenerateNumbersForEquation(expression, existingUnknowns)).Evaluate();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}