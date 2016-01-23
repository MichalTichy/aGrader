using System;

namespace aGrader.sourceCodes
{
    class SourceCodeC :SourceCode
    {
        public SourceCodeC(string path) : base(path)
        {
            
        }
        public override string ToString()
        {
            return Name;
        }
        public override void GetCompilationError()
        {
            Tuple<string, int?> compilationError = new TestC(null,null).GetCompilationError(this);

            if (compilationError.Item1 != null)
            {
                CompilationErrorMsg = compilationError.Item1;
                NumberOfLineWithError = compilationError.Item2;
            }
        }
    }
}
