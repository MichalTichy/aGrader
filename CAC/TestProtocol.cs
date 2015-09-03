using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAC.IO_Forms;
using CAC.Mathematic;

namespace CAC
{
    public class TestProtocol
    {
        private double _maximumDeviation=0.001;
        private List<string> _inputs = new List<string>();
        private List<object> _outputs = new List<object>();
        private List<string> _prohibitedCommnads=new List<string>();
        private List<string> _requiedCommnads = new List<string>();

        private readonly Dictionary<string, decimal> _generatedRandomNumbers=new Dictionary<string, decimal>();

#region encapsulation
        public double MaximumDeviation
        {
            get { return _maximumDeviation; }
        }

        public ReadOnlyCollection<string> Inputs
        {
            get { return _inputs.AsReadOnly(); }
        }

        public ReadOnlyCollection<object> Outputs
        {
            get { return _outputs.AsReadOnly(); }
        }

        public ReadOnlyCollection<string> ProhibitedCommnads
        {
            get { return _prohibitedCommnads.AsReadOnly(); }
        }

        public ReadOnlyCollection<string> RequiedCommnads
        {
            get { return _requiedCommnads.AsReadOnly(); }
        }
#endregion

        public TestProtocol()
        {
            foreach (dynamic data in InputsOutputs.GetList())
                ProcessData(data);
            _prohibitedCommnads = _prohibitedCommnads.Distinct().ToList();
            _requiedCommnads = _requiedCommnads.Distinct().ToList();
        }

        private void ProcessData(InputString input)
        {
            _inputs.Add(input.Text);
        }

        private void ProcessData(InputNumber input)
        {
            _inputs.Add(input.Value.ToString().Replace(',', '.'));
        }

        private  void ProcessData(InputRandomNumber input)
        {
            var random = new Random(DateTime.Now.Millisecond);
            decimal num;
            if (input.Decimal)
            {
                decimal next = (decimal)random.NextDouble();
                num = input.Min + (next * (input.Max - input.Min));
                num = Math.Round(num, 3);
            }
            else
            {
                num = random.Next((int)input.Min, (int)input.Max);
            }

            _inputs.Add(num.ToString().Replace(',', '.'));
            _generatedRandomNumbers.Add('X' + input.Id, num);
        }
        private void ProcessData(InputTextFile input) //todo dodělat
        {
            throw new NotImplementedException();
        }
        private void ProcessData(OutputNumber output)
        {
            _outputs.Add(new NumberData(output.Value));
        }

        private void ProcessData(OutputNumberBasedOnRandomInput output)
        {
            var equation = new Mathematic.MathExpresion(output.Math, _generatedRandomNumbers);
           _outputs.Add(new NumberData((decimal)equation.Evaluate()));
        }

        private void ProcessData(OutputString output)
        {
            _outputs.Add(new TextData(output.Text));
        }

        private void ProcessData(OutputNumberMatchingConditions output)
        {
            _outputs.Add(new NumberMatchingConditionsData(output.Conditions));
        }

        private void ProcessData(OutputCountOfNumbersMatchingConditions output)
        {
            int count;
            if (output.TakesInputs())
            {
                decimal result;
                var numbers = _inputs.Where(s => decimal.TryParse(s, out result));
                count = numbers.Count(number => MathExpresion.AreAllConditionsTrue(decimal.Parse(number), output.Conditions,MaximumDeviation));
            }
            else
            {
                count = _outputs.Cast<NumberData>().Count(num => MathExpresion.AreAllConditionsTrue(num.Data, output.Conditions,MaximumDeviation));
            }
            _outputs.Add(new NumberData(count));
        }
        private void ProcessData(SettingsDeviation deviation)
        {
            _maximumDeviation = deviation.Deviation;
        }

        private void ProcessData(SettingsProhibitedCommand prohibitedCommand)
        {
            _prohibitedCommnads.Add(prohibitedCommand.Text);
        }

        private void ProcessData(SettingsRequiedCommand requiedCommand)
        {
            _prohibitedCommnads.Add(requiedCommand.Text);
        }

        private void ProcessData(ActionRepeatLast repeatLast)
        {
            dynamic repeatedForm = repeatLast.GetRepeatedForm();
            for (int i = 0; i < repeatLast.Repetitions; i++)
            {
                if (repeatedForm is InputRandomNumber)
                {

                    repeatedForm.Id = Guid.NewGuid().ToString();
                }
                ProcessData(repeatedForm);
            }
        }
    }
}
