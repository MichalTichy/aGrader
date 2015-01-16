using System.IO;

namespace CAC
{
    public class SourceCode
    {
        private string _path;
        private string _name;

        public SourceCode(string path)
        {
            _path = path;
            _name = Path.GetFileName(path);
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetPath()
        {
            return _path;
        }

        public string GetSourceCode()
        {
            return File.ReadAllText(_path);
        }

        public bool Exists()
        {
            if (File.Exists(_path))
                return true;
            return false;
        }
    }
}
