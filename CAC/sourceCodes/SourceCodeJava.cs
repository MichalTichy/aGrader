using System;

namespace aGrader.sourceCodes
{
    public class SourceCodeJava : SourceCode
    {
        public readonly string[] Dependencies;

        public SourceCodeJava(string path) : base(path)
        {
        }

        public SourceCodeJava(string pathToMain, string[] dependencies) : base(pathToMain)
        {
            Dependencies = dependencies;
        }


        public override void GetCompilationError()
        {
            throw new NotImplementedException();
        }
    }
}