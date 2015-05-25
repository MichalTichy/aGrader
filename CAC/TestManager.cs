﻿#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using CAC.IO_Forms;
using CAC.Math;
using CAC.SourceCodes;

#endregion

namespace CAC
{
    public static class TestManager
    {
        private static double _deviation = 0.001; //default deviatio
        private static List<string> _inputs = new List<string>();
        private static List<KeyValuePair<string, OutputType>> _outputs = new List<KeyValuePair<string, OutputType>>();
        private static Dictionary<string, decimal> _randomNumbers = new Dictionary<string, decimal>();
        private static List<string> _prohibitedCommnads = new List<string>();
        private static List<string> _requiedCommnads = new List<string>();

        public static double Deviation
        {
            get { return _deviation; }
        }

        public static void TestAllSourceCodes()
        {
            GetInputsAndOutputs();
            foreach (SourceCode code in SourceCodes.SourceCodes.GetSourceCodeFiles())
            {
                SourceCode code1 = code;
                CheckSourceCodeForProhibitedCommands(code1);
                CheckSourceCodeForRequiedCommands(code1);
                var thread = new Thread(delegate() { code1.RunTest(_inputs, _outputs); });
                thread.Start(); //todo dodelat moznost zastavit praci
            }
        }

        private static void CheckSourceCodeForRequiedCommands(SourceCode code1)
        {
            string sourceCode = File.ReadAllText(code1.Path);
            foreach (
                string requiedCommnad in _requiedCommnads.Where(requiedCommnad => sourceCode.Contains(requiedCommnad)))
            {
                code1.AddTestError("Nenalezen vyžadovaný příkaz: " + requiedCommnad);
            }
        }

        private static void CheckSourceCodeForProhibitedCommands(SourceCode code1)
        {
            string sourceCode = File.ReadAllText(code1.Path);
            foreach (
                string prohibitedCommnad in
                    _prohibitedCommnads.Where(prohibitedCommnad => sourceCode.Contains(prohibitedCommnad)))
            {
                code1.AddTestError("Nalezen nepovolený příkaz: " + prohibitedCommnad);
            }
        }

        private static void GetInputsAndOutputs()
        {
            _inputs.Clear();
            _outputs.Clear();
            _randomNumbers.Clear();
            foreach (dynamic data in InputsOutputs.GetList())
                ProcessData(data);
        }

        private static void ProcessData(InputString input)
        {
            _inputs.Add(input.Text);
        }

        private static void ProcessData(InputNumber input)
        {
            _inputs.Add(input.Value.ToString().Replace(',', '.'));
        }

        private static void ProcessData(InputRandomNumber input)
        {
            var random = new Random(DateTime.Now.Millisecond);
            decimal num;
            if (input.Decimal)
            {
                decimal next = (decimal) random.NextDouble();
                num = input.Min + (next*(input.Max - input.Min));
                num = System.Math.Round(num, 3);
            }
            else
            {
                num = random.Next((int) input.Min, (int) input.Max);
            }
            _inputs.Add(num.ToString().Replace(',', '.'));
            _randomNumbers.Add('X' + input.Id.ToString(), num);
            Thread.Sleep(1); //to ensure random numbers
        }

        private static void ProcessData(InputTextFile input) //todo dodělat
        {
            throw new NotImplementedException();
        }

        private static void ProcessData(OutputNumber output)
        {
            _outputs.Add(new KeyValuePair<string, OutputType>(output.Value.ToString(), OutputType.Number));
        }

        private static void ProcessData(OutputNumberBasedOnRandomInput output)
        {
            var equation = new Equation(output.Math, _randomNumbers);
            _outputs.Add(new KeyValuePair<string, OutputType>(equation.Evaluate().ToString(), OutputType.Number));
        }

        private static void ProcessData(OutputString output)
        {
            _outputs.Add(new KeyValuePair<string, OutputType>(output.Text, OutputType.Text));
        }

        private static void ProcessData(OutputNumberMatchingConditions output)
        {
            string conditions = "";
            foreach (string condition in output.Conditions)
            {
                if (conditions != "")
                    conditions += '\n';
                conditions += condition;
            }
            _outputs.Add(new KeyValuePair<string, OutputType>(conditions, OutputType.Math));
        }

        private static void ProcessData(SettingsDeviation deviation)
        {
            _deviation = deviation.Deviation;
        }

        private static void ProcessData(SettingsProhibitedCommand prohibitedCommand)
        {
            if (!_prohibitedCommnads.Contains(prohibitedCommand.Text))
                _prohibitedCommnads.Add(prohibitedCommand.Text);
        }

        private static void ProcessData(SettingsRequiedCommand requiedCommand)
        {
            if (!_requiedCommnads.Contains(requiedCommand.Text))
                _requiedCommnads.Add(requiedCommand.Text);
        }

        private static void ProcessData(ActionRepeatLast repeatLast)
        {
            for (int i = 0; i < repeatLast.Repetitions; i++)
                ProcessData(InputsOutputs.GetIOForm(InputsOutputs.GetIdOfForm(repeatLast) - 1));
        }
    }

    public enum OutputType
    {
        Number,
        Text,
        Math,
        None
    }
}