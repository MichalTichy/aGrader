using System.IO;

namespace CAC
{
    public class SourceCode
    {
        public readonly string Path;
        private readonly string _name;

        public SourceCode(string path)
        {
            Path = path;
            _name = System.IO.Path.GetFileName(path);
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetSourceCode()
        {
            return File.ReadAllText(Path);
        }

        public bool Exists()
        {
            if (File.Exists(Path))
                return true;
            return false;
        }
    }
}