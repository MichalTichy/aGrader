#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CAC.Mathematic
{
    public static class MathValidator
    {
        public static bool IsValid(string equation, List<string> existingUnknowns)
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
                var eq = new Math(equation, numbersForEquation);
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
            List<string> existingUnknowns)
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
    }
}