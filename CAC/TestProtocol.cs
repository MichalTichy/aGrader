using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using aGrader.IOForms;
using aGrader.Mathematic;

namespace aGrader
{
    public class TestProtocol
    {
        private double _maximumDeviation=0.001;
        private int _timeout = 20000;
        public string StartupArguments { get; private set; }
        public List<string> Inputs = new List<string>();
        public List<object> Outputs = new List<object>();
        private List<string> _prohibitedCommnads=new List<string>();
        private List<string> _requiedCommnads = new List<string>();
        private Random random=new Random(DateTime.Now.Millisecond);
        private readonly Dictionary<string, decimal> _generatedRandomNumbers=new Dictionary<string, decimal>();

#region encapsulation
        public double MaximumDeviation => _maximumDeviation;

        public ReadOnlyCollection<string> ProhibitedCommnads => _prohibitedCommnads.AsReadOnly();

        public ReadOnlyCollection<string> RequiedCommnads => _requiedCommnads.AsReadOnly();

        public int Timeout => _timeout;

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
            Inputs.Add(input.Text);
        }

        private void ProcessData(InputNumber input)
        {
            Inputs.Add(input.Value.ToString().Replace(',', '.'));
        }

        private  void ProcessData(InputRandomNumber input)
        {
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

            Inputs.Add(num.ToString().Replace(',', '.'));
            _generatedRandomNumbers.Add('X' + input.Id, num);
        }
        private void ProcessData(InputTextFile input)
        {
            string line;
            using (var file = new StreamReader(input.Path))
            {
                while((line=file.ReadLine())!=null)
                {
                    Inputs.Add(line);
                }
            }
        }
        private void ProcessData(OutputNumber output)
        {
            Outputs.Add(new NumberData(output.Value));
        }

        private void ProcessData(OutputNumberBasedOnRandomInput output)
        {
            var equation = new MathExpresion(output.Math, _generatedRandomNumbers);
           Outputs.Add(new NumberData((decimal)equation.Evaluate()));
        }

        private void ProcessData(OutputString output)
        {
            Outputs.Add(new TextData(output.Text));
        }

        private void ProcessData(OutputNumberMatchingConditions output)
        {
            Outputs.Add(new NumberMatchingConditionsData(output.Conditions));
        }

        private void ProcessData(OutputCountOfNumbersMatchingConditions output)
        {
            int count;
            if (output.TakesInputs())
            {
                decimal result;
                var numbers = Inputs.Where(s => decimal.TryParse(s, out result));
                count = numbers.Count(number => BooleanExpresion.AreAllConditionsTrue(decimal.Parse(number), output.Conditions));
            }
            else
            {
                count = Outputs.Cast<NumberData>().Count(num => MathExpresion.AreAllConditionsTrue(num.Data, output.Conditions,MaximumDeviation));
            }
            Outputs.Add(new NumberData(count));
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

        private void ProcessData(SettingsTimeout timeout)
        {
            _timeout = timeout.Timeout;
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

        private void ProcessData(ActionLoadOutputsFromTextFile sourceFile)
        {
            Outputs.Add(new FileWithOutputsData());
        }

        private void ProcessData(ActionCompareFiles actionCompareFiles)
        {
            try
            {
                Outputs.Add(actionCompareFiles.radioHash.Checked
                    ? new FileCompareData(actionCompareFiles.Path,
                        File.ReadAllText(actionCompareFiles.Path).GetHashCode())
                    : new FileCompareData(actionCompareFiles.Path, File.ReadAllLines(actionCompareFiles.Path)));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor " + Path.GetFileName(actionCompareFiles.Path) + " neexistuje.");
            }
            catch (IOException ex)
            {
                //todo neplaty testovaci protokol by mnel zabranit spusteni testu
                MessageBox.Show("Soubor " + Path.GetFileName(actionCompareFiles.Path) + " se nepodařilo načíst.");
                ExceptionsLog.LogException(ex.ToString());
            }
        }

        private void ProcessData(SettingsStartupArguments settingsStartupArguments)
        {
            StartupArguments = settingsStartupArguments.Arguments;
        }
    }
}
