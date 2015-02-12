using System;

namespace CAC
{
    public static class EquationValidator
    {
        public static bool IsValid(string equation)
        {
            decimal[] numbersForEquation = GenerateNumbersForEquation(equation);
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

        private static decimal[] GenerateNumbersForEquation(string equation)
        {
            int countOfUnknownNumbers = GetCountOfUnknownsInEquation(equation);
            decimal[] numbersForEquation = new decimal[countOfUnknownNumbers];

            for (int i = 0; i < countOfUnknownNumbers; i++)
            {
                numbersForEquation[i] = i + 1; //+1 kvůli zamezení případného dělení nulou
            }
            return numbersForEquation;
        }

        private static int GetCountOfUnknownsInEquation(string equation)
        {
            int i = 0;
            while (equation.Contains('X' + i.ToString()))
                i++;
            return i + 1;
        }
    }
}