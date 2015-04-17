﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAC.IO_Forms;
using CAC.Math;
using CAC.SourceCodes;

namespace CAC
{
    
    public static class TestManager
    {

        
        private static List<string> _inputs = new List<string>();
        private static List<string> _outputs = new List<string>();
        private static Dictionary<string, decimal> _randomNumbers = new Dictionary<string, decimal>();

        public static void TestAllSourceCodes()
        {
            GetInputsAndOutputs();
            foreach (SourceCode code in SourceCodes.SourceCodes.GetSourceCodeFiles())
            {
                var code1 = code;
                Thread thread = new Thread(delegate() { code1.RunTest(_inputs,_outputs); });
                thread.Start(); //todo dodelat moznost zastavit praci
            }
        }

        private static void GetInputsAndOutputs()
        {
            _inputs.Clear();
            _outputs.Clear();
            _randomNumbers.Clear();
            foreach (var InOut in InputsOutputs.GetList())
                GetData(InOut);
        }

        private static void GetData(InputString input)
        {
            _inputs.Add(input.Text);
        }
        private static void GetData(InputNumber input)
        {
            _inputs.Add(input.Value.ToString());
        }
        private static void GetData(InputRandomNumber input)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            decimal num;
            if (input.Decimal)
            {
                decimal next = (decimal)random.NextDouble();
                num = input.Min + (next * (input.Max - input.Min));
            }
            else
            {
                num = random.Next((int)input.Min, (int)input.Max);
            }
            _inputs.Add(num.ToString());
            _randomNumbers.Add('X' + input.ID.ToString(), num);
            Thread.Sleep(1); //to ensure random numbers
        }
        private static void GetData(InputTextFile input)//todo dodělat
        {
            throw new NotImplementedException();
        }

        private static void GetData(OutputNumber output)
        {
            _outputs.Add(output.Value.ToString());
        }
        private static void GetData(OutputNumberBasedOnRandomInput output)
        {
            Equation equation = new Equation(output.jahoda, _randomNumbers);
            _outputs.Add(equation.Evaluate().ToString());
        }
        private static void GetData(OutputString output)
        {
            _outputs.Add(output.Text);
        }
    }
}