#region

using System;
using System.Collections.Generic;
using System.Data;

#endregion

namespace CAC.Mathematic
{
    public class MathExpresion
    {
        private string _mathExpresion;
        private Dictionary<string, decimal> _unknownNumbers;

        public MathExpresion(string mathExpresion, Dictionary<string, decimal> unknownNumbers)
        {
            _mathExpresion = mathExpresion;
            _unknownNumbers = unknownNumbers;
            InsertUnkownNumbersIntoEquation();
        }

        public MathExpresion(string mathExpresion, decimal number)
        {
            _mathExpresion = mathExpresion;
            _unknownNumbers = new Dictionary<string, decimal> {{"X", number}};
            InsertUnkownNumbersIntoEquation();
        }

        private void InsertUnkownNumbersIntoEquation()
        {
            foreach (KeyValuePair<string, decimal> x in _unknownNumbers)
            {
                _mathExpresion = _mathExpresion.Replace(x.Key, x.Value.ToString());
            }
            _mathExpresion = _mathExpresion.Replace(',', '.');
        }

        public static bool AreAllConditionsTrue(decimal number, List<string> conditions, double maximumDeviation)
        {
            foreach (string condition in conditions)
            {
                var math = new MathExpresion(condition.Split('=')[0].Replace(" ", ""), number);
                double d1 = math.Evaluate();
                double d2 = double.Parse(condition.Split('=')[1].Replace(" ", ""));

                if ((Math.Abs(d1 - d2) < maximumDeviation)) continue;
                return false;
            }
            return true;
        }

        public double Evaluate()
        {
            //Vypujceno z WEBU
            var table = new DataTable();
            table.Columns.Add("myExpression", string.Empty.GetType(), _mathExpresion);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string) row["myExpression"]);
        }
    }
}