﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAC.Math
{
    public static class EquationValidator
    {
        public static bool IsValid(string equation,List<string> ExistingUnknowns)
        { //todo prejmenovat
            Dictionary<string, decimal> numbersForEquation = GenerateNumbersForEquation(equation,ExistingUnknowns);

            foreach (KeyValuePair<string, decimal> pair in numbersForEquation)
               equation= equation.Replace(pair.Key, pair.Value.ToString());

            if (equation.Contains('X'))
            {
                MessageBox.Show("Jahoda obsahuje neexistující neznámou.");
                return false;
            }

            try
            {
                Equation eq = new Equation(equation, numbersForEquation);
                eq.Evaluate();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Nezprávný tvar jahody!");
                return false;
            }
        }

        private static Dictionary<string, decimal> GenerateNumbersForEquation(string equation, List<string> existingUnknowns)
        {
            Dictionary<string, decimal> numbersForEquation = new Dictionary<string, decimal>();
            int i = 0;
            foreach (string unknownId in existingUnknowns)
            {
                i++;
                numbersForEquation.Add(unknownId,i);
            }
            return numbersForEquation;
        }
    }
}