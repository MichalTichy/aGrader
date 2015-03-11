using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CAC
{
    public static class EquationValidator
    {
        public static bool IsValid(string equation)
        { //todo prejmenovat
            Dictionary<string, decimal> numbersForEquation = GenerateNumbersForEquation(equation);
            try
            {
                Equation eq = new Equation(equation, numbersForEquation);
                eq.Evaluate();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Dictionary<string, decimal> GenerateNumbersForEquation(string equation)
        {
            Dictionary<string, decimal> numbersForEquation = new Dictionary<string, decimal>();
            int i = 0;
            foreach (string unknownId in GetUnknownsFromEquation(equation))
            {
                i++;
                numbersForEquation.Add(unknownId,i);
            }
            return numbersForEquation;
        }

        public static List<string> GetUnknownsFromEquation(string equation)
        {
            return Regex.Matches(equation, @"X\d*").Cast<Match>()
                .Select(m => m.Groups[0].Value)
                .ToList();
        }
    }
}