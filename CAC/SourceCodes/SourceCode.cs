using System.IO;
using System.Text.RegularExpressions;

namespace CAC.SourceCodes
{
    public class SourceCode
    {
        public readonly string Path;
        private readonly string _name;
        private string _errorMSG;

        public SourceCode(string path)
        {
            Path = path;
            _name = System.IO.Path.GetFileName(path);
            _errorMSG = new TestedCode(path).GetError();
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetSourceCode()
        {
            return File.ReadAllText(Path);
        }

        public string GetErrorMessage()
        {
            return _errorMSG;
        }
        public int GetIdOfLineWithError()
        {
            if (_errorMSG == null)
                return -1;
            Regex newRegex= new Regex(@":(\d):");
            return int.Parse(newRegex.Match(_errorMSG).ToString().Replace(":", "")) - 2;
        }

        public bool Exists()
        {
            if (File.Exists(Path))
                return true;
            return false;
        }
    }
}