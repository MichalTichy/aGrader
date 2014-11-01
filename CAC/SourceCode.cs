using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CAC
{
    public class SourceCode
    {
        private string path;
        private string name;

        public SourceCode(string path)
        {
            this.path = path;
            this.name = Path.GetFileName(path);
        }

        public override string ToString()
        {
            return name;
        }

        public string GetPath()
        {
            return path;
        }
    }
}
