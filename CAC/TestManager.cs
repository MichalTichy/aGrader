#region

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using aGrader.Properties;
using aGrader.sourceCodes;

#endregion

namespace aGrader
{
    public class ResultReadyArgs : EventArgs
    {
        public TestResult Result { get; set; }
    }
    public static class TestManager
    {
        public static event EventHandler<ResultReadyArgs> ResultReady;
        private static TestProtocol _protocol;
        public static async void TestAllSourceCodes()
        {
            _protocol = new TestProtocol();

            var testTasks= SourceCodes.GetSourceCodeFiles().Select(sourceCode => CreateTestTask(sourceCode)).ToList();
            testTasks.ForEach(t=>t.Start());
            while (testTasks.Count>0)
            {
                Task<TestResult> firstFinishedTask = await Task.WhenAny(testTasks);
                testTasks.Remove(firstFinishedTask);
                TestResult result = await firstFinishedTask;
                OnResultReady(result);
            }
        }

        private static Task<TestResult> CreateTestTask(SourceCode sourceCode)
        {
            if (sourceCode is SourceCodeC)
                return new Task<TestResult>(new TestC(sourceCode, _protocol).RunTest);
            if (sourceCode is SourceCodeJava)
                return new Task<TestResult>(new TestJava(sourceCode, _protocol).RunTest);

            MessageBox.Show(Resources.TestManager_UnsuportedTypeOfSourceCode);
            throw new ApplicationException($"Unsupoorted type of SourceCode! {sourceCode.GetType()}");
        }

        private static void OnResultReady(TestResult result)
        {
            ResultReady?.Invoke(typeof(TestManager),new ResultReadyArgs() {Result = result});
        }
    }
}