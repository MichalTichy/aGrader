using System;
using System.Linq;
using aGrader.Properties;

namespace aGrader.sourceCodes
{
    public class SourceCodeJava : SourceCode
    {
        public string[] Dependencies { get; set; }

        public SourceCodeJava(string path) : base(path)
        {
        }

        public SourceCodeJava(string name,string[] pathToMain, string[] dependencies) : base(pathToMain.Count()!=0?pathToMain[0]:null)
        {
            Name = name;
            Dependencies = dependencies;
            if (!pathToMain.Any())
            {
                CompilationErrors.Add(new Tuple<string, int?>(Resources.SourceCodeJava_NoFileWithMainFound,null));
            }
            else if (pathToMain.Count() > 1)
            {
                CompilationErrors.Add(new Tuple<string, int?>(Resources.SourceCodeJava_MultipleFilesWithMainFound, null));
            }
        }

        public override void GetCompilationError()
        {
            CompilationErrors = new TestJava(this, new TestProtocol()).GetCompilationError();
        }
    }
}