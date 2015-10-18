using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace aGrader
{
    internal struct TextData
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

    internal struct NumberData
    {
        public decimal Data;

        public NumberData(decimal data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString().Replace('.', ',');
        }
    }

    internal struct NumberMatchingConditionsData
    {
        public List<string> Conditions;

        public NumberMatchingConditionsData(List<string> conditions)
        {
            Conditions = conditions;
        }

        public override string ToString()
        {
            string conditions = "";
            var sb = new StringBuilder(conditions);
            foreach (string condition in Conditions)
            {
                sb.Append(condition);
            }
            return conditions;
        }
    }

    internal struct FileCompareData
    {
        public string RefereceFilePath;
        public int? ReferenceFileHash;
        public string[] ReferenceFileLines;

        public FileCompareData(string path, int referenceFileHash)
        {
            RefereceFilePath = path;
            ReferenceFileHash = referenceFileHash;
            ReferenceFileLines = null;
        }

        public FileCompareData(string path, string[] referenceFileLines)
        {
            RefereceFilePath = path;
            ReferenceFileHash = null;
            ReferenceFileLines = referenceFileLines;
        }
    }

    internal struct LineFromTextFileData
    {
        public int LineNumber;
        private string _text;

        public LineFromTextFileData(string line, int lineNumber)
        {
            LineNumber = lineNumber;
            _text = line;
        }

        public override string ToString()
        {
            return _text;
        }
    }

    internal struct FileHashData
    {
        public string FilePath;
        private int? _hash;
        public FileHashData(string filePath)
        {
            FilePath = filePath;
            _hash = null;
        }

        public override string ToString()
        {
            try
            {
                if (_hash == null)
                    _hash = File.ReadAllText(FilePath).GetHashCode();
                return _hash.ToString();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Soubor " + Path.GetFileName(FilePath) + "se nepodaøilo naèíst.");
                ExceptionsLog.LogException(ex.ToString());
                return "FILE LOAD ERROR";
            }
        }
    }

    internal struct FileWithOutputsData
    {
    }

    internal struct ErrorData
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