using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aGrader.sourceCodes
{
    class SourceCodeC :SourceCode
    {
        public SourceCodeC(string path) : base(path)
        {
            
        }
        
        public override void GetCompilationError()
        {
            Tuple<string, int?> compilationError = Test.GetCompilationError(this);

            if (compilationError.Item1 != null)
            {
                CompilationErrorMsg = compilationError.Item1;
                NumberOfLineWithError = compilationError.Item2;
            }
        }
    }
}
