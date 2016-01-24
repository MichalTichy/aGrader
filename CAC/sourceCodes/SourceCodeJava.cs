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
                CompilationErrorMsg = Resources.SourceCodeJava_NoFileWithMainFound;
            }
            else if (pathToMain.Count() > 1)
            {
                CompilationErrorMsg = Resources.SourceCodeJava_MultipleFilesWithMainFound;
            }
        }

        public override void GetCompilationError()
        {
          //  throw new NotImplementedException();
        }
    }
}