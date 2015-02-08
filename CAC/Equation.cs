using System.Data;
using System.Linq;

namespace CAC
{
    public class Equation
    {
        private string _equation;
        private decimal[] _unknownNumbers;

        public Equation(string equation, decimal[] unknownNumbers)
        {
            _equation = equation;
            _unknownNumbers = unknownNumbers;
            InsertUnkownNumbersIntoEquation();
        }

        private void InsertUnkownNumbersIntoEquation()
        {
            //nezname v rovnici musi byt oznaceny jako X+index (X0,X1,...)
            for (int i = 0; i < _unknownNumbers.Count(); i++)
            {
                _equation = _equation.Replace("X" + i, _unknownNumbers[i].ToString());
            }
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