using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ciloci.Flee;

namespace CAC.Mathematic
{
    class BooleanExpresion
    {
        private string _booleanExpresion;
        private Dictionary<string, decimal> _unknownNumbers;
        private ExpressionContext context=new ExpressionContext();
        public BooleanExpresion(string booleanExpresion, Dictionary<string, decimal> unknownNumbers)
        {
            _booleanExpresion = booleanExpresion;
            _unknownNumbers = unknownNumbers;
            
            BuildExpressionContext();
        }

        public BooleanExpresion(string booleanExpresion, decimal value)
        {
            _booleanExpresion = booleanExpresion;
            _unknownNumbers = new Dictionary<string, decimal> {{"X", value}};
        }


        public bool Evaluate()
        {
            IGenericExpression<bool> e = context.CompileGeneric<bool>(_booleanExpresion);
            return e.Evaluate();
        }

        private void BuildExpressionContext()
        {
            VariableCollection collection = context.Variables;
            foreach (KeyValuePair<string, decimal> unknownNumber in _unknownNumbers)
            {
                collection.Add(unknownNumber.Key,unknownNumber.Value);
            }
        }

        public static bool AreAllConditionsTrue(decimal number, List<string> conditions)
        {
            foreach (string condition in conditions)
            {
                var d = new Dictionary<string, decimal> {{"X", number}};
                if (!new BooleanExpresion(condition, d).Evaluate())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
