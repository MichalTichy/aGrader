using System;
using System.Collections.Generic;
using System.Text;

namespace CAC
{
    struct TextData
    {
        public string Data;

        public TextData(string data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data;
        }
    }

    struct NumberData
    {
        public decimal Data;

        public NumberData(decimal data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    struct NumberMatchingConditionsData
    {
        public List<string> Conditions;

        public NumberMatchingConditionsData(List<string> conditions)
        {
            Conditions = conditions;
        }

        public override string ToString()
        {
            string conditions="";
            var sb=new StringBuilder(conditions);
            foreach (string condition in Conditions)
            {
                sb.Append(condition);
            }
            return conditions;
        }
    }

    struct ErrorData
    {
        public readonly string ErrorMsg;

        public ErrorData(string errorMsg)
        {
            ErrorMsg = errorMsg;
        }

        public override string ToString()
        {
            return ErrorMsg;
        }
    }
}