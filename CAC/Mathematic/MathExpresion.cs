#region

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