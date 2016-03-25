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
            CompilationErrors = new TestC(this,new TestProtocol()).GetCompilationError();
        }
    }
}
