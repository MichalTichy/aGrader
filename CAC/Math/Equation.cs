using System.Collections.Generic;
using System.Data;

namespace CAC.Math
{
    public class Equation
    { //todo prejmenovat
        private string _equation;
        private Dictionary<string,decimal> _unknownNumbers;

        public Equation(string equation, Dictionary<string, decimal> unknownNumbers)
        {
            _equation = equation;
            _unknownNumbers = unknownNumbers;
            InsertUnkownNumbersIntoEquation();
        }

        private void InsertUnkownNumbersIntoEquation()
        {
            foreach (KeyValuePair<string, decimal> x in _unknownNumbers)
            {
                _equation=_equation.Replace(x.Key, x.Value.ToString());
            }
           _equation = _equation.Replace(',', '.');
        }

        public double Evaluate()
        {
            //Vypujceno z WEBU
            DataTable table = new DataTable();
            table.Columns.Add("myExpression", string.Empty.GetType(), _equation);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string) row["myExpression"]);
        }
    }
}